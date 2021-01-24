//METHOD FROM ISSUE NO.1
public bool Login(string userName, string pass)
{
 bool answer="";
 foreach(UserAccount acc in UserAccount.ListOfUsers)
  {
   if(acc.UserName==userName && acc.Password == pass)
   { 
     if(acc.AdminRights==true)
     {
      Console.WriteLine("You have Admin Rights");
      answer=true;
     }
     else
     Console.WriteLine("You do not have Admin rights");
     answer= false;
     }
   }
  else
  Console.WriteLine("Account does not exist");
  answer= false;
 }
 answer odgovor;
}
This thing would never compile. Why would you initiate a boolean variable with `""`? And what is `answer odgovor`? And why is your method not returning anything?
However the reason because the method returns `false` is because you have two places like this:
  if
  {
    ...
  }
  else
  Console.WriteLine("Account does not exist");
  answer= false;
... which translates to ...
  if
  {
    ...
  }
  else
  {
    Console.WriteLine("Account does not exist");
  }
  answer= false;
... because you left out the `{}` after `else`. So the code will always reach `answer = false`, whether or not the login was successful or not. 
You could have found this easily by stepping through the code with the debugger.
---
The second one ... well ...
//METHOD FROM ISSUE NO.2
public string PatientById(string ID)
{
    string answer= "";
    foreach(Patient p in Patient.ListOfPatients)
    {
        if (p.ID == ID)
        {
            answer = "patient ID :" + p.ID + " Name: " + p.name + "  LastName: " +                             p.lastName; 
        }
        else
        {
            answer = "The patient with this ID does not exist";
        }
    }
    return answer;
}
What's happening here is that you might find many patients by a given id but even if you did, you'll always overwrite the prior strings with a new one. That's the reason why only the last match will be returned.
