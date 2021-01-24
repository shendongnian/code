        public interface IContactsStore
        {
            Task<ContactsFile> ReadAsync();
        }
        public class DefaultContactsStore : IContactsStore
        {
            private readonly IHostingEnvironment env;
            public DefaultContactsStore(IHostingEnvironment env)
            {
                this.env = env;
            }
            public async Task<ContactsFile> ReadAsync()
            {
                String path = Path.Combine( this.env.ContentRootPath, "Contacts.json" );
                
                String fileContents;
                using( StreamReader rdr = new StreamReader( path ) )
                {
                    fileContents = await rdr.ReadToEndAsync();
                }
                return JsonConvert.DeserializeObject<ContactsFile>( fileContents );
            }
        }
        public class MyController : Controller
        {
            private readonly IContactsStore contactsStore; 
            public MyController( IContactsStore contactsStore )
            {
                this.contactsStore = contactsStore;
            }
            [Route("/contacts")]
            public async Task<IActionResult> ListContacts()
            {
                ContactsFile cf = await this.contactsStore.ReadAsync();
                
                return this.View( model: cf );
            }
        }
        // In Startup.cs:
        public void ConfigureService( ... )
        {
            // etc
            services.AddSingleton<IContactsStore,DefaultContactsStore>();
            // etc
        }
