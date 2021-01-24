    case "/deposit":
          //Deposit Money
                            
          decimal C;
          string D;
          Console.WriteLine("How much you want to deposit?");
          C = Convert.ToDecimal(Console.ReadLine());
          Console.WriteLine("Add a note:");
          D = Console.ReadLine();
          account.MakeDeposit(C, DateTime.Now, D);
          Console.WriteLine($"Maked a deposit of {C.ToString()}$!");
          break;
