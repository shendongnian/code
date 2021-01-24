using System;
using System.Threading;
using Google.Contacts;
using Google.GData.Contacts;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
namespace SharedContactsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello !! ");
            //Get Auth
            OAuth2Parameters p = ContactsAuth();
            ////Create a domain shared contact
            try
            {
                RequestSettings settings = new RequestSettings("GSuiteAdminApp", p);
                ContactsRequest contactreq = new ContactsRequest(settings);
                Console.WriteLine("Attempting to create a Domain Shared Contact in GSuite");
                Console.WriteLine(" ");
                CreateContact(contactreq);
            }
            catch (Exception e44)
            {
                Console.WriteLine(e44.Message);
            }
        }
        //Create Shared Contact
        public static Contact CreateContacttest(ContactsRequest cr)
        {
            Contact newEntry = new Contact();
            // Set the contact's name.
            newEntry.Name = new Name()
            {
                FullName = "Ice Cold005",
                GivenName = "Ice",
                FamilyName = "Cold005"
            };
            newEntry.Content = "Notes";
            // Set the contact's e-mail addresses.
            newEntry.Emails.Add(new EMail()
            {
                Primary = true,
                Rel = ContactsRelationships.IsWork,
                Address = "ice.cold005@xyz.com"
            });
            //Insert the contact
            Uri feedUri = new Uri(ContactsQuery.CreateContactsUri("test.com"));
            Contact createdEntry = cr.Insert(feedUri, newEntry);
            Console.WriteLine("New Contact created successfully with ContactID = " + createdEntry.Id);
            return createdEntry;
        }
        //Auth for Contacts API
        public static OAuth2Parameters ContactsAuthtest()
        {
            string clientId = "xxxxxxxxxxxxxxxxxxxxx.apps.googleusercontent.com";
            string clientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxx";
            string[] scopes = new string[] { "https://www.google.com/m8/feeds/contacts/" };
            try
            {
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }, scopes, "super-admin@test.com", CancellationToken.None, new FileDataStore("C:\\Temp\\A\\SharedContactsOauth")).Result;
                // Translate the Oauth permissions to something the old client libray can read
                OAuth2Parameters parameters = new OAuth2Parameters();
                parameters.AccessToken = credential.Token.AccessToken;
                parameters.RefreshToken = credential.Token.RefreshToken;
                return parameters;
            }
            catch (Exception ex33)
            {
                Console.WriteLine(ex33.Message);
                return null;
            }
        }
    }
}
