 static void DisplayDelegateInfo(Delegate d)
        {
            foreach (Delegate member in d.GetInvocationList())
            {
                Console.WriteLine($"Method name: {member.Method}");
                Console.WriteLine($"Type name: {member.Target}");               
            }
        }
