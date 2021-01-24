    [HttpPost]
        public IActionResult AddTask(TaskViewModel taskVM)
        {
            Models.Tasks.Task task = taskVM.Task;
            _context.Add(task);
            _context.SaveChanges();
            
            foreach(var selectedId in taskVM.selectedCategories)
            {
                _context.TaskCategory.Add(new TaskCategory
                {
                    TaskId = task.Id,
                    CategoryId = selectedId,
                });
            }
            _context.SaveChanges();
     
            return RedirectToAction("Index");
            
        }
