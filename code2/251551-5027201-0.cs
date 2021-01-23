    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User { UserName = "Tom" };
            User user2 = new User { UserName = "Pete" };
            List<UserChoice> userChoices = new List<UserChoice>
            {
                new UserChoice { User = user1, ChosenValue = "chosenValue1", Year = 1994 },
                new UserChoice { User = user1, ChosenValue = "chosenValue3", Year = 1995 },
                new UserChoice { User = user1, ChosenValue = "chosenValue1", Year = 1996 },
                new UserChoice { User = user1, ChosenValue = "chosenValue2", Year = 1997 },
                new UserChoice { User = user1, ChosenValue = "chosenValue2", Year = 1998 },
                new UserChoice { User = user1, ChosenValue = "chosenValue1", Year = 1999 },
                new UserChoice { User = user1, ChosenValue = "chosenValue2", Year = 2000 },
                new UserChoice { User = user2, ChosenValue = "chosenValue3", Year = 1994 },
                new UserChoice { User = user2, ChosenValue = "chosenValue1", Year = 1995 },
                new UserChoice { User = user2, ChosenValue = "chosenValue2", Year = 1996 },
                new UserChoice { User = user2, ChosenValue = "chosenValue3", Year = 1997 },
                new UserChoice { User = user2, ChosenValue = "chosenValue1", Year = 1998 },
                new UserChoice { User = user2, ChosenValue = "chosenValue2", Year = 1999 },
                new UserChoice { User = user2, ChosenValue = "chosenValue1", Year = 2000 }
            };
            var choicesByYear = (from uc in userChoices
                                 group uc by uc.Year into g
                                 select new { Year = g.Key, UserChoicesByYear = g });
            foreach (var item in choicesByYear)
            {
                Console.WriteLine("Choices for year: " + item.Year);
                foreach (var userChoice in item.UserChoicesByYear)
                {
                    Console.WriteLine(userChoice.User.UserName + " chose " + userChoice.ChosenValue.ToString());
                }
            }
            Console.ReadKey();
        }
    }
    public class UserChoice {
        public User User { get; set; }
        public int Year { get; set; }
        public object ChosenValue { get; set; }
    }
    public class User {
        public string UserName { get; set; }
    }
