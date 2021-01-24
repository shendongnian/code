    public static class RequestFactory
    {
        public static IRequest<Form> Create(FormParams formParams)
        {
    
            if (formParams == FormParams.Book)
            {
                return new Request<Book>();
            }
            if (formParams == FormParams.Copybook)
            {
                return new Request<Copybook>();
            }
            return new Request<Notebook>();
        } 
    }
