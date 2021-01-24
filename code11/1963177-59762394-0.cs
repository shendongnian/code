public class ARRenderThread : Thread, ISurfaceHolderCallback2
        {
            RecordableSurfaceView mSurfaceView;
            EGLDisplay mEGLDisplay;
            EGLContext mEGLContext;
            EGLSurface mEGLSurface;
            EGLSurface mEGLSurfaceMedia;
            public LinkedList<Runnable> mRunnableQueue = new LinkedList<Runnable>();
            int[] config = new int[] {
                    EGL14.EglRedSize, 8,
                    EGL14.EglGreenSize, 8,
                    EGL14.EglBlueSize, 8,
                    EGL14.EglAlphaSize, 8,
                    EGL14.EglRenderableType, EGL14.EglOpenglEs2Bit,
                    EGLExt.EglRecordableAndroid, 1,
//                    EGL14.EglSurfaceType, EGL14.EglPbufferBit,
                    EGL14.EglDepthSize, 16,
                    EGL14.EglNone
            };
            public ARRenderThread(RecordableSurfaceView surfaceView)
            {
                this.mSurfaceView = surfaceView;
                if (Build.VERSION.SdkInt >= Build.VERSION_CODES.O)
                {
                    config[10] = EGLExt.EglRecordableAndroid;
                }
            }
            public AtomicBoolean mLoop = new AtomicBoolean(false);
            EGLConfig chooseEglConfig(EGLDisplay eglDisplay)
            {
                int[] configsCount = new int[] { 0 };
                EGLConfig[] configs = new EGLConfig[1];
                EGL14.EglChooseConfig(eglDisplay, config, 0, configs, 0, configs.Length, configsCount,
                        0);
                return configs[0];
            }
            public override void Run()
            {
                if (mSurfaceView.mHasGLContext.Get())
                {
                    return;
                }
                mEGLDisplay = EGL14.EglGetDisplay(EGL14.EglDefaultDisplay);
                int[] version = new int[2];
                EGL14.EglInitialize(mEGLDisplay, version, 0, version, 1);
                EGLConfig eglConfig = chooseEglConfig(mEGLDisplay);
                mEGLContext = EGL14
                        .EglCreateContext(mEGLDisplay, eglConfig, EGL14.EglNoContext,
                                new int[] { EGL14.EglContextClientVersion, 2, EGL14.EglNone }, 0);
                int[] surfaceAttribs = {
                            EGL14.EglNone
                    };
                mEGLSurface = EGL14
                        .EglCreateWindowSurface(mEGLDisplay, eglConfig, mSurfaceView,
                                surfaceAttribs, 0);
                EGL14.EglMakeCurrent(mEGLDisplay, mEGLSurface, mEGLSurface, mEGLContext);
                // guarantee to only report surface as created once GL context
                // associated with the surface has been created, and call on the GL thread
                // NOT the main thread but BEFORE the codec surface is attached to the GL context
                RendererCallbacks result;
                if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                {
                    result.onSurfaceCreated();
                }
                mSurfaceView.mMediaSurfaceCreated.Set(false);
                GLES20.GlClearColor(0.1f, 0.1f, 0.1f, 1.0f);
                mSurfaceView.mHasGLContext.Set(true);
                if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                {
                    result.onContextCreated();
                }
                mLoop.Set(true);
                while (mLoop.Get())
                {
                    if (!mSurfaceView.mPaused)
                    {
                        bool shouldRender = false;
                        //we're just rendering when requested, so check that no one
                        //has requested and if not, just continue
                        if (mSurfaceView.mRenderMode.Get() == (int)Rendermode.WhenDirty)
                        {
                            if (mSurfaceView.mRenderRequested.Get())
                            {
                                mSurfaceView.mRenderRequested.Set(false);
                                shouldRender = true;
                            }
                        }
                        else
                        {
                            shouldRender = true;
                        }
                        if (mSurfaceView.mSizeChange.Get())
                        {
                            GLES20.GlViewport(0, 0, mSurfaceView.mWidth, mSurfaceView.mHeight);
                            if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                            {
                                result.onSurfaceChanged(mSurfaceView.mWidth, mSurfaceView.mHeight);
                            }
                            mSurfaceView.mSizeChange.Set(false);
                        }
                        if (shouldRender)
                        {
                            if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                            {
                                result.onPreDrawFrame();
                            }
                            if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                            {
                                result.onDrawScreen();
                            }
                            EGL14.EglSwapBuffers(mEGLDisplay, mEGLSurface);
                            if (mSurfaceView.mIsRecording.Get())
                            {
                                if (!mSurfaceView.mMediaSurfaceCreated.Get())
                                {
                                    mEGLSurfaceMedia = EGL14
                                        .EglCreateWindowSurface(mEGLDisplay, eglConfig, mSurfaceView.mSurface,
                                                surfaceAttribs, 0);
                                    mSurfaceView.mMediaSurfaceCreated.Set(true);
                                }
                                EGL14.EglMakeCurrent(mEGLDisplay, mEGLSurfaceMedia, mEGLSurfaceMedia,
                                        mEGLContext);
                                if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                                {
                                    GLES20.GlViewport(0, 0, mSurfaceView.mOutWidth, mSurfaceView.mOutHeight);
                                    //EGLExt.EglPresentationTimeANDROID(mEGLDisplay, mEGLSurfaceMedia, (JavaSystem.CurrentTimeMillis() - RecordableSurfaceView.mStartTimeMillisecs) * 1000L *1000L);
                                    result.onDrawRecording();
                                    GLES20.GlViewport(0, 0, mSurfaceView.mWidth, mSurfaceView.mHeight);
                                }
                                EGL14.EglSwapBuffers(mEGLDisplay, mEGLSurfaceMedia);
                                EGL14.EglMakeCurrent(mEGLDisplay, mEGLSurface, mEGLSurface,
                                        mEGLContext);
                            }
                        }
                        while (mRunnableQueue.Count > 0)
                        {
                            Runnable ev = mRunnableQueue.First.Value;
                            mRunnableQueue.RemoveFirst();
                            ev.Run();
                        }
                    }
                    /*
                    try
                    {
                        Thread.Sleep((long)(1f / 120.0f * 1000f));
                    }
                    catch (InterruptedException intex) // THIS IS KEY TO BLACKOUT BUG, THIS CATCH NEVER HAPPENS AND SO THE OLD SURFACE IS NEVER NUKED / REMADE mHasGLContext NEVER SET TO FALSE
                    {
                        if (mSurfaceView.mRendererCallbacksWeakReference != null && mSurfaceView.mRendererCallbacksWeakReference.TryGetTarget(out result))
                        {
                            result.onSurfaceDestroyed();
                        }
                        if (mEGLDisplay != null)
                        {
                            EGL14.EglMakeCurrent(mEGLDisplay, EGL14.EglNoSurface,
                                    EGL14.EglNoSurface,
                                    EGL14.EglNoContext);
                            if (mEGLSurface != null)
                            {
                                EGL14.EglDestroySurface(mEGLDisplay, mEGLSurface);
                            }
                            if (mEGLSurfaceMedia != null)
                            {
                                EGL14.EglDestroySurface(mEGLDisplay, mEGLSurfaceMedia);
                            }
                            EGL14.EglDestroyContext(mEGLDisplay, mEGLContext);
                            mSurfaceView.mHasGLContext.Set(false);
                            EGL14.EglReleaseThread();
                            EGL14.EglTerminate(mEGLDisplay);
                            mSurfaceView.mSurface.Release();
                        }
                        return;
                    }*/
                }
            }
            public void SurfaceRedrawNeeded(ISurfaceHolder surfaceHolder)
            {
            }
            public void SurfaceCreated(ISurfaceHolder surfaceHolder)
            {
                if (!this.IsAlive && !this.IsInterrupted && this.GetState() != State.Terminated)
                {
                    this.Start();
                }
            }
            public void SurfaceChanged(ISurfaceHolder surfaceHolder, Android.Graphics.Format i, int width, int height)
            {
                if (mSurfaceView.mWidth != width)
                {
                    mSurfaceView.mWidth = width;
                    mSurfaceView.mSizeChange.Set(true);
                }
                if (mSurfaceView.mHeight != height)
                {
                    mSurfaceView.mHeight = height;
                    mSurfaceView.mSizeChange.Set(true);
                }
            }
            public void SurfaceDestroyed(ISurfaceHolder surfaceHolder)
            {
                mLoop.Set(false);
                this.Interrupt();
                mSurfaceView.Holder.RemoveCallback(this);
                //MOVED SURFACE DESTROYING CODE TO FUNCTION CALLED WHEN APP IS PAUSED INSTEAD OF UNSTABLE CATCH UPON RETURN_______
                if (mEGLDisplay != null)
                {
                    EGL14.EglMakeCurrent(mEGLDisplay, EGL14.EglNoSurface,
                            EGL14.EglNoSurface,
                            EGL14.EglNoContext);
                    if (mEGLSurface != null)
                    {
                        EGL14.EglDestroySurface(mEGLDisplay, mEGLSurface);
                    }
                    if (mEGLSurfaceMedia != null)
                    {
                        EGL14.EglDestroySurface(mEGLDisplay, mEGLSurfaceMedia);
                    }
                    EGL14.EglDestroyContext(mEGLDisplay, mEGLContext);
                    mSurfaceView.mHasGLContext.Set(false);
                    EGL14.EglReleaseThread();
                    EGL14.EglTerminate(mEGLDisplay);
                    mSurfaceView.mSurface.Release();
                }
                //______________________________________________________________________________________________________________
            }
        }
    }
}
