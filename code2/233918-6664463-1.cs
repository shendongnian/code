    public void test()
        {
            myContext context = new myContext();
            Processor p = new Processor
            {
                ProcessorDLL = getSomeRandomByteArray()
            };
            context.Processors.Add(p);
            context.SaveChanges();
        }
