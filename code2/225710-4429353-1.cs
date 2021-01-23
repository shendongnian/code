    /// Usage:
    this.lblTimeDisplay.SafeInvoke(() => this.lblTimeDisplay.Text = this.task.Duration.ToString(), false);
    
    // or 
    string taskName = string.Empty;
    this.txtTaskName.SafeInvoke(() => taskName = this.txtTaskName.Text, true);
    /// <summary>
    /// Execute a method on the control's owning thread.
    /// </summary>
    /// <param name="uiElement">The control that is being updated.</param>
    /// <param name="updater">The method that updates uiElement.</param>
    /// <param name="forceSynchronous">True to force synchronous execution of 
    /// updater.  False to allow asynchronous execution if the call is marshalled
    /// from a non-GUI thread.  If the method is called on the GUI thread,
    /// execution is always synchronous.</param>
    public static void SafeInvoke(this Control uiElement, Action updater, bool forceSynchronous)
    {
        if (uiElement == null)
        {
            throw new ArgumentNullException("uiElement");
        }
    
        if (uiElement.InvokeRequired)
        {
            if (forceSynchronous)
            {
                uiElement.Invoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
            }
            else
            {
                uiElement.BeginInvoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
            }
        }
        else
        {
            if (!uiElement.IsHandleCreated)
            {
                // Do nothing if the handle isn't created already.  The user's responsible
                // for ensuring that the handle they give us exists.
                return;
            }
    
            if (uiElement.IsDisposed)
            {
                throw new ObjectDisposedException("Control is already disposed.");
            }
    
            updater();
        }
    }
