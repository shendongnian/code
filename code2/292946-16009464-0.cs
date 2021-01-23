    IEnumerable<User> users = db.Users.Include("Projects.Tasks.Messages");
    
    foreach (User user in users)
    {
        Console.WriteLine(user.Name);
        foreach (Project project in user.Projects)
        {
            Console.WriteLine("\t"+project.Name);
            foreach (Task task in project.Tasks)
            {
                Console.WriteLine("\t\t" + task.Subject);
                foreach (Message message in task.Messages)
                {
                    Console.WriteLine("\t\t\t" + message.Text);
                }
            }
        }
    }
