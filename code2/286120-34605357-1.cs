    public class MyBindingSource
        : BindingSource,
          ISupportInitialize
    {
        void ISupportInitialize.BeginInit()
        {
            this.InvokeBaseBeginInit();
            // More begin init logic
        }
        void ISupportInitialize.EndInit()
        {
            this.InvokeBaseEndInit();
            // More end init logic
        }
    }
