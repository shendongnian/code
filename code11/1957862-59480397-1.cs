public enum Symptoms
        {
            HEADACHE =1,
            VOMITING =2,
            CRAMP =3,
            RASH =4,
            COUGH = 5,
            FATIGUE =6,
            NAUSEA =7,
            DIZZINESS =8,
            COLD =9,
            CHESTPAIN =10,
            INFECTION =11,
            FLU =12,
            HEALTHY =13,
            PRESCRIBEANTIBIOTICS =14,
            PRESCRIBEPAINKILLERS =15,
            GATROENTERITIS =16
        }
and you can use this in your process.. Rids of a lot of process.
    public static void userInput()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n Which of these medical conditions do you have? Please type the corresponding number:" +
                    "\n 1. headache \n 2. vomiting \n 3. cramp \n 4. rash \n 5. cough \n 6. fatigue \n 7. nausea \n 8. dizziness" +
                    "\n 9. cold \n 10. chestPain \n 11. infection \n 12. flu \n 13. healthy \n 14. prescribeAntibiotics \n" +
                    " 15. prescribePainkillers \n 16. gastroenteritis ");
                string StringInput = Console.ReadLine();
                int.TryParse(StringInput, out int number);
                
                if (number > 0 && number < 17)
                {
                    // you can do other things as well here with the symptom
                    Symptoms symptom = (Symptoms)Enum.Parse(typeof(Symptoms), StringInput);
                    FACTS[symptom.ToString()] = true;
                }
                Console.WriteLine("Do you want to exit [N]?");
                if (Console.ReadKey().Key == ConsoleKey.N)
                    break;
            }
        }
and you can fix your AddFacts method to following:
    public static void addFACTS()
        {
            foreach (var x in Enum.GetValues(typeof(Symptoms)))
                FACTS.Add(x.ToString(), false);
        }
