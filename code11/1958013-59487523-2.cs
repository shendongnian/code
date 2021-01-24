// You can pass many arguments you want here
string fullNameOfPerson3 = PersonHelper.GetFullName(person3.FirstName, person3.SurName, person3.Patronymic);
// And get them by using this method
string GetFullName(params string[] args)
Full method:
    public static class PersonHelper
    {
        public static string GetFullName(params string[] args)
        {
            string result = "";
            for (int i = 0; i < args.Length; i++)
            {
                result += i == args.Length - 1 ? args[i] : args[i] + " ";
            }
            return result;
        }
    }
**Full code:** (this is only a very simple example. Try the way with your project)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArrayFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Person1 person1 = new Person1();
            Person2 person2 = new Person2();
            Person2 person3 = new Person2();
            string fullNameOfPerson1 = PersonHelper.GetFullName(person1.Name, person1.FamilyName, person1.Patronymic);
            string fullNameOfPerson2 = PersonHelper.GetFullName(person2.FirstName, person2.SurName, person2.Patronymic);
            string fullNameOfPerson3 = PersonHelper.GetFullName(person3.FirstName, person3.SurName, person3.Patronymic);
        }
    }
    public static class PersonHelper
    {
        public static string GetFullName(params string[] args)
        {
            string result = "";
            for (int i = 0; i < args.Length; i++)
            {
                result += i == args.Length - 1 ? args[i] : args[i] + " ";
            }
            return result;
        }
    }
    public class Person1
    {
        public string Name { set; get; }
        public string FamilyName { set; get; }
        public string Patronymic { set; get; }
    }
    public class Person2
    {
        public string FirstName { set; get; }
        public string SurName { set; get; }
        public string Patronymic { set; get; }
    }
    public class Person3
    {
        public string PersonName { set; get; }
        public string Surname { set; get; }
        public string Patr { set; get; }
    }
}
