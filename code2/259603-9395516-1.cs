                Console.WriteLine("Service EndPoints are: ");
                foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine("{0} ({1})", endpoint.Address.ToString(), endpoint.Binding.Name);
                }
                host.Open();
                
                Console.WriteLine(string.Concat("Service is host at ", DateTime.Now.ToString()));
                Console.WriteLine("\n Self Host is running... Press <Enter> key to stop");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
