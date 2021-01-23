    private void InitUIState(ViewMode mode)
    {
          if (this.InvokeRequired())
          {
              // .. other business logic only here relevant
              // to the worker process ..
              this.BeginInvoke((MethodInvoker)delegate
              {
                  InitUIState(mode);
              });
          } else {
              this.labelProgramStatus.Text = CONSOLE_IDLE_STATUS;
         }
    }
