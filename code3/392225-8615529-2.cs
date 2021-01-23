            if (this._resizer != null)
            {
                this._resizer.DragStarted -= new DragStartedEventHandler(Resizer_DragStarted);
                this._resizer.DragCompleted -= new DragCompletedEventHandler(Resizer_DragCompleted);
                this._resizer.MouseMove -= new MouseEventHandler(Resizer_MouseMove);
            }
            this._resizer = this.GetTemplateChild("Resizer") as Thumb;
            if (this._resizer != null)
            {
                this._resizer.DragStarted += new DragStartedEventHandler(Resizer_DragStarted);
                this._resizer.DragCompleted += new DragCompletedEventHandler(Resizer_DragCompleted);
                this._resizer.MouseMove += new MouseEventHandler(Resizer_MouseMove);
            }
