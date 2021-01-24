// add this line outside (above) the while loop: (you will need to import the proper namespace for this: `using System.Collections.Generic;`)
List<Customer> newCustomers = new List<Customer>();
// I renamed this variable. add the line below to put the new customer into the list
customer newCustomer = new customer(userInputName, userInputInitial, userInputMonthly);
newCustomers.Add(newCustomer);
// now you have a list of new customers you can reference outside the while loop.
