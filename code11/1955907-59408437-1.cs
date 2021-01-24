        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>()
            {
                new Task() {duration = 4, type = "A"},
                new Task() {duration = 2, type = "B"},
                new Task() {duration = 6, type = "C"},
                new Task() {duration = 8, type = "D"}
            };
            List<Span> spans = new List<Span>()
            {
                new Span() {from = 9, to = 10},
                new Span() {from = 11, to = 13},
                new Span() {from = 15, to = 20}
            };
            IEnumerable<Assignment> assignments = AssignTasks(tasks, spans);
            Console.WriteLine("Tasks: duration, type");
            foreach (Task task in tasks)
            {
                Console.WriteLine($"{task.duration}, {task.type}");
            }
            Console.WriteLine("\nSpans: from, to");
            foreach (Span span in spans)
            {
                Console.WriteLine($"{span.from}, {span.to}");
            }
            Console.WriteLine("\nResults: from, to, type");
            foreach (Assignment assignment in assignments)
            {
                Console.WriteLine($"{assignment.span.from}, {assignment.span.to}, {assignment.type}");
            }
            Console.ReadLine();
        }
