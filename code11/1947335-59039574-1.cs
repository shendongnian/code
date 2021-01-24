    private class CustomTagWorkerFactory : DefaultTagWorkerFactory {
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context) {
            if (TagConstants.P.Equals(tag.Name().ToLower())) {
                return new CustomPTagWorker(tag, context);
            }
            return base.GetCustomTagWorker(tag, context);
        }
    }
