    public void Synchronize()
    {
        PresentationSource criticalActiveSource = this.CriticalActiveSource;
        if (((criticalActiveSource != null) && (criticalActiveSource.CompositionTarget != null)) && !criticalActiveSource.CompositionTarget.IsDisposed)
        {
            InputReportEventArgs args;
            int tickCount = Environment.TickCount;
            Point clientPosition = this.GetClientPosition();
            RawMouseInputReport report = new RawMouseInputReport(InputMode.Foreground, tickCount, criticalActiveSource, RawMouseActions.AbsoluteMove, (int) clientPosition.X, (int) clientPosition.Y, 0, IntPtr.Zero);
            report._isSynchronize = true;
            if (this._stylusDevice != null)
            {
                args = new InputReportEventArgs(this._stylusDevice, report);
            }
            else
            {
                args = new InputReportEventArgs(this, report);
            }
            args.RoutedEvent = InputManager.PreviewInputReportEvent;
            this._inputManager.Value.ProcessInput(args);
        }
    }
