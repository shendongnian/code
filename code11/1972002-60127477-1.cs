    public class PublicationApiClient<T> : IPublicationApiClient<T> where T : Publication
    {
        public bool Send(Request<T> publication)
        {
            Console.WriteLine($"Hello from {typeof(T).Name} client!");
            return true;
        }
        public Response<T> UpdatingRecv(Request<T> publication)
        {
            throw new NotImplementedException();
        }
    }
    static void Main(string[] args)
    {
        ServiceProvider provider = new ServiceCollection()
            .AddSingleton<IClientFactory, ClientFactory>()
            .AddSingleton(typeof(IPublicationApiClient<>), typeof(PublicationApiClient<>))
            .BuildServiceProvider();
        IClientFactory factory = provider.GetService<IClientFactory>();
        Book book = new Book();
        IPublicationApiClient<Book> bookClient = factory.Create(book);
        bookClient.Send(new Request<Book>(book));
        NoteBook notebook = new NoteBook();
        IPublicationApiClient<NoteBook> notebookClient = factory.Create(notebook);
        notebookClient.Send(new Request<NoteBook>(notebook));
        Console.ReadLine();
    }
