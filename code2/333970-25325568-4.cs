    public abstract class ReadOnlyActionFilterAttribute : ActionFilterAttribute
    {
        private delegate void ReadOnlyOnClose(Stream stream);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new OnCloseFilter(
                filterContext.HttpContext.Response.Filter, 
                this.OnClose);
            base.OnActionExecuting(filterContext);
        }
        protected abstract void OnClose(Stream stream);
        private class OnCloseFilter : MemoryStream
        {
            private readonly Stream stream;
            private readonly ReadOnlyOnClose onClose;
            public OnCloseFilter(Stream stream, ReadOnlyOnClose onClose)
            {
                this.stream = stream;
                this.onClose = onClose;
            }
            public override void Close()
            {
                this.Position = 0;
                this.onClose(this);
                this.Position = 0;
                this.CopyTo(this.stream);
                base.Close();
            }
        }
    }
