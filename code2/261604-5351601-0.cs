    abstract class DocumentTemplateBase
    {
        public abstract void WriteTitle();
        public abstract void WriteSections();
    }
    abstract class DocumentTemplate : DocumentTemplateBase
    {
        public override sealed void WriteTitle() 
        {
            Console.WriteLine("Project document"); 
        }
        public override sealed void WriteSections() 
        {
            Console.WriteLine("Sections");
        }
        abstract public void WriteContent();
    }
