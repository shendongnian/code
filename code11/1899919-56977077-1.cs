    public class BlockWriterFactory
    {
        public BlockWriter GetBlockWriter(Block block)
        {
            if (block is TextBlock)
                return new TextBlockWriter();
            if (block is TableBlock)
                return new TableBlockWriter();
            if (block is ListBlock)
                return new ListBlockWriter();
            // this could be a "null" class or some fallback
            // default implementation. You could also choose to
            // throw an exception.
            return new NullBlockWriter();
        }
    }
