        class Task
        {
            public int duration;
            public string type;
            public int remaining;
            public void Reset()
            {
                remaining = duration;
            }
        }
        class Span
        {
            public int from;
            public int to;
            public int remaining;
            public int duration => to - from;
            public void Reset()
            {
                remaining = duration;
            }
        }
        struct Assignment
        {
            public Span span;
            public string type;
        }
        static IEnumerable<Assignment> AssignTasks(List<Task> tasks, List<Span> spans)
        {
            // add an infinite span to the end of list
            spans.Add(new Span()
            {
                from = spans.Last().to,
                to = int.MaxValue
            });
            // set remainings of tasks and spans by their total duration
            foreach (Task task in tasks) { task.Reset(); }
            foreach (Span span in spans) { span.Reset(); }
            // set current task and span
            int iTask = 0;
            int iSpan = 0;
            while (iTask < tasks.Count)
            {
                //find which is smaller: remaining part of current task, or 
                // remaining part of current span
                int assigning =
                tasks[iTask].remaining <= spans[iSpan].remaining ?
                    tasks[iTask].remaining : spans[iSpan].remaining;
                // add a new assignment to results
                yield return new Assignment()
                {
                    span = new Span()
                    {
                        from = spans[iSpan].to - spans[iSpan].remaining,
                        to = spans[iSpan].to - spans[iSpan].remaining + assigning,
                    },
                    type = tasks[iTask].type
                };
                // update remaining parts of current task and span
                tasks[iTask].remaining -= assigning;
                spans[iSpan].remaining -= assigning;
                // update counters if nothing is left 
                if (tasks[iTask].remaining == 0)
                    iTask++;
                if (spans[iSpan].remaining == 0)
                    iSpan++;
            }
        }
