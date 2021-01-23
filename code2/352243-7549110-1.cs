    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ManagedDirectX;
    using Windows.Storage;
    using Windows.Storage.Streams;
    namespace TestProgram
    {
        public sealed class EntryPoint
        {
            public void NtfyExecutionAbrt()
            {
            }
            
            public EntryPoint()
            {
                beginexecblock();
            }
            void onrenderframe()
            {
                if(vertcount>0) {
                    maincontext.Draw(vertcount);
                }
            }
            int vertcount = 0;
            Shader defaultshader;
            RenderContext maincontext;
            async void beginexecblock()
            {
                if ((await Windows.Storage.ApplicationData.Current.RoamingFolder.GetFilesAsync()).Count == 0)
                {
                    await ApplicationData.Current.RoamingFolder.CreateFileAsync("testfile.txt");
                    ApplicationData.Current.SignalDataChanged();
                    Windows.UI.Popups.MessageDialog tdlg = new Windows.UI.Popups.MessageDialog("Roaming file creation success", "Sync status");
                    await tdlg.ShowAsync();    
                }
                try
                {
                    DateTime started = DateTime.Now;
                    RenderContext mtext = new RenderContext();
                    maincontext = mtext;
                    StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                    StorageFile file = await folder.GetFileAsync("DXInteropLib\\VertexShader.cso");
                    
                    var stream = (await file.OpenAsync(FileAccessMode.Read));
                    Windows.Storage.Streams.DataReader mreader = new Windows.Storage.Streams.DataReader(stream.GetInputStreamAt(0));
                    byte[] dgram = new byte[file.Size];
                    await mreader.LoadAsync((uint)dgram.Length);
                    mreader.ReadBytes(dgram);
                    file = await folder.GetFileAsync("DXInteropLib\\PixelShader.cso");
    
                    stream = await file.OpenAsync(FileAccessMode.Read);
                    mreader = new Windows.Storage.Streams.DataReader(stream.GetInputStreamAt(0));
                    byte[] mgram = new byte[file.Size];
                    await mreader.LoadAsync((uint)file.Size);
                    mreader.ReadBytes(mgram);
                    try
                    {
                        defaultshader = mtext.CreateShader(dgram, mgram);
                        mtext.InitializeLayout(dgram);
                        defaultshader.Apply();
                        mtext.OnRenderFrame += onrenderframe;
                    }
                    catch (Exception er)
                    {
                        Windows.UI.Popups.MessageDialog mdlg = new Windows.UI.Popups.MessageDialog(er.ToString(),"Fatal error");
                        mdlg.ShowAsync().Start();
                    }
                    IStorageFile[] files = (await folder.GetFilesAsync()).ToArray();
                    bool founddata = false;
                    foreach (IStorageFile et in files)
                    {
                        if (et.FileName.Contains("rawimage.dat"))
                        {
                            stream = await et.OpenAsync(FileAccessMode.Read);
                            founddata = true;
                        }
                    }
                    int width;
                    int height;
                    byte[] rawdata;
                    if (!founddata)
                    {
                        file = await folder.GetFileAsync("TestProgram\\test.png");
                        stream = await file.OpenAsync(FileAccessMode.Read);
                        var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                        var pixeldata = await decoder.GetPixelDataAsync(Windows.Graphics.Imaging.BitmapPixelFormat.Rgba8, Windows.Graphics.Imaging.BitmapAlphaMode.Straight, new Windows.Graphics.Imaging.BitmapTransform(), Windows.Graphics.Imaging.ExifOrientationMode.IgnoreExifOrientation, Windows.Graphics.Imaging.ColorManagementMode.DoNotColorManage);
                        width = (int)decoder.PixelWidth;
                        height = (int)decoder.PixelHeight;
    
                        rawdata = pixeldata.DetachPixelData();
                        file = await folder.CreateFileAsync("rawimage.dat");
                        stream = (await file.OpenAsync(FileAccessMode.ReadWrite));
                        var realstream = stream.GetOutputStreamAt(0);
                        DataWriter mwriter = new DataWriter(realstream);
                        mwriter.WriteInt32(width);
                        mwriter.WriteInt32(height);
                        mwriter.WriteBytes(rawdata);
                        await mwriter.StoreAsync();
                        await realstream.FlushAsync();
                    }
                    else
                    {
                        DataReader treader = new DataReader(stream.GetInputStreamAt(0));
                        await treader.LoadAsync((uint)stream.Size);
                        rawdata = new byte[stream.Size-(sizeof(int)*2)];
                        width = treader.ReadInt32();
                        height = treader.ReadInt32();
                        treader.ReadBytes(rawdata);
                    }
                    Texture2D mtex = maincontext.createTexture2D(rawdata, width, height);
                    List<VertexPositionNormalTexture> triangle = new List<VertexPositionNormalTexture>();
                    triangle.Add(new VertexPositionNormalTexture(new Vector3(-.5f,-.5f,0),new Vector3(1,1,1),new Vector2(0,0)));
                    triangle.Add(new VertexPositionNormalTexture(new Vector3(0,0.5f,0),new Vector3(1,1,1),new Vector2(1,0)));
                    triangle.Add(new VertexPositionNormalTexture(new Vector3(.5f,-0.5f,0),new Vector3(1,1,1),new Vector2(1,1)));
                    byte[] gpudata = VertexPositionNormalTexture.Serialize(triangle.ToArray());
                    
                    VertexBuffer mbuffer = maincontext.createVertexBuffer(gpudata,VertexPositionNormalTexture.Size);
                    mbuffer.Apply(VertexPositionNormalTexture.Size);
                    vertcount = 3;
                    Windows.UI.Popups.MessageDialog tdlg = new Windows.UI.Popups.MessageDialog("Unit tests successfully completed\nShader creation: Success\nTexture load: Success\nVertex buffer creation: Success\nTime:"+(DateTime.Now-started).ToString(), "Results");
                    tdlg.ShowAsync().Start();
                }
                catch (Exception er)
                {
                    Windows.UI.Popups.MessageDialog tdlg = new Windows.UI.Popups.MessageDialog(er.ToString(), "Fatal error");
                    tdlg.ShowAsync().Start();
                }
            }    
        }
    }
