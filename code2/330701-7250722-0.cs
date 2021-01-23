    public class VideoSourceToVideo : IDisposable
    {
        object locker = new object();
        public event EventHandler<EventArgs> Starting;
        public event EventHandler<EventArgs> Stopping;
        public event EventHandler<EventArgs> Completed;
        /// <summary> graph builder interface. </summary>
        private DirectShowLib.ICaptureGraphBuilder2 captureGraphBuilder = null;
        DirectShowLib.IMediaControl mediaCtrl = null;
        IMediaEvent mediaEvent = null;
        bool stopMediaEventLoop = false;
        Thread mediaEventThread;
        /// <summary> Dimensions of the image, calculated once in constructor. </summary>
        private readonly VideoInfoHeader videoInfoHeader;
        IVideoSource source;
        public VideoSourceToVideo(IVideoSource source, string destFilename, string encoderName)
        {
            try
            {
                this.source = source;
                // Set up the capture graph
                SetupGraph(destFilename, encoderName);
            }
            catch
            {
                Dispose();
                throw;
            }
        }
        /// <summary> release everything. </summary>
        public void Dispose()
        {
            StopMediaEventLoop();
            CloseInterfaces();
        }
        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(string destFilename, string encoderName)
        {
            int hr;
            // Get the graphbuilder object
            captureGraphBuilder = new DirectShowLib.CaptureGraphBuilder2() as DirectShowLib.ICaptureGraphBuilder2;
            IFilterGraph2 filterGraph = new DirectShowLib.FilterGraph() as DirectShowLib.IFilterGraph2;
            mediaCtrl = filterGraph as DirectShowLib.IMediaControl;
            IMediaFilter mediaFilt = filterGraph as IMediaFilter;
            mediaEvent = filterGraph as IMediaEvent;
            captureGraphBuilder.SetFiltergraph(filterGraph);
            IBaseFilter aviMux;
            IFileSinkFilter fileSink = null;
            hr = captureGraphBuilder.SetOutputFileName(MediaSubType.Avi, destFilename, out aviMux, out fileSink);
            DsError.ThrowExceptionForHR(hr);
            DirectShowLib.IBaseFilter compressor = DirectShowUtils.GetVideoCompressor(encoderName);
            if (compressor == null)
            {
                throw new InvalidCodecException(encoderName);
            }
            hr = filterGraph.AddFilter(compressor, "compressor");
            DsError.ThrowExceptionForHR(hr);
            // Our data source
            IBaseFilter source = (IBaseFilter)new GenericSampleSourceFilter();
            // Get the pin from the filter so we can configure it
            IPin ipin = DsFindPin.ByDirection(source, PinDirection.Output, 0);
            try
            {
                // Configure the pin using the provided BitmapInfo
                ConfigurePusher((IGenericSampleConfig)ipin);
            }
            finally
            {
                Marshal.ReleaseComObject(ipin);
            }
            // Add the filter to the graph
            hr = filterGraph.AddFilter(source, "GenericSampleSourceFilter");
            Marshal.ThrowExceptionForHR(hr);
            hr = filterGraph.AddFilter(source, "source");
            DsError.ThrowExceptionForHR(hr);
            hr = captureGraphBuilder.RenderStream(null, null, source, compressor, aviMux);
            DsError.ThrowExceptionForHR(hr);
            IMediaPosition mediaPos = filterGraph as IMediaPosition;
            hr = mediaCtrl.Run();
            DsError.ThrowExceptionForHR(hr);
        }
        private void ConfigurePusher(IGenericSampleConfig ips)
        {
            int hr;
            source.SetMediaType(ips);
            // Specify the callback routine to call with each sample
            hr = ips.SetBitmapCB(source);
            DsError.ThrowExceptionForHR(hr);
        }
        private void StartMediaEventLoop()
        {
            mediaEventThread = new Thread(MediaEventLoop)
            {
                Name = "Offscreen Vid Player Medialoop",
                IsBackground = false
            };
            mediaEventThread.Start();
        }
        private void StopMediaEventLoop()
        {
            stopMediaEventLoop = true;
            if (mediaEventThread != null)
            {
                mediaEventThread.Join();
            }
        }
        public void MediaEventLoop()
        {
            MediaEventLoop(x => PercentageCompleted = x);
        }
        public double PercentageCompleted
        {
            get;
            private set;
        }
        // FIXME this needs some work, to be completely in-tune with needs.
        public void MediaEventLoop(Action<double> UpdateProgress)
        {
            mediaEvent.CancelDefaultHandling(EventCode.StateChange);
            //mediaEvent.CancelDefaultHandling(EventCode.Starvation);
            while (stopMediaEventLoop == false)
            {
                try
                {
                    EventCode ev;
                    IntPtr p1, p2;
                    if (mediaEvent.GetEvent(out ev, out p1, out p2, 0) == 0)
                    {
                        switch (ev)
                        {
                            case EventCode.Complete:
                                Stopping.Fire(this, null);
                                if (UpdateProgress != null)
                                {
                                    UpdateProgress(source.PercentageCompleted);
                                }
                                return;
                            case EventCode.StateChange:
                                FilterState state = (FilterState)p1.ToInt32();
                                if (state == FilterState.Stopped || state == FilterState.Paused)
                                {
                                    Stopping.Fire(this, null);
                                }
                                else if (state == FilterState.Running)
                                {
                                    Starting.Fire(this, null);
                                }
                                break;
                            // FIXME add abort and stuff, and propagate this.
                        }
                        //                        Trace.WriteLine(ev.ToString() + " " + p1.ToInt32());
                        mediaEvent.FreeEventParams(ev, p1, p2);
                    }
                    else
                    {
                        if (UpdateProgress != null)
                        {
                            UpdateProgress(source.PercentageCompleted);
                        }
                        // FiXME use AutoResetEvent
                        Thread.Sleep(100);
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine("MediaEventLoop: " + e);
                }
            }
        }
        /// <summary> Shut down capture </summary>
        private void CloseInterfaces()
        {
            int hr;
            try
            {
                if (mediaCtrl != null)
                {
                    // Stop the graph
                    hr = mediaCtrl.Stop();
                    mediaCtrl = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            if (captureGraphBuilder != null)
            {
                Marshal.ReleaseComObject(captureGraphBuilder);
                captureGraphBuilder = null;
            }
            GC.Collect();
        }
        public void Start()
        {
            StartMediaEventLoop();
        }
    }
