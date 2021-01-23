        private void Form2_Load(object sender, EventArgs e)
        {
            Model1 model = new Model1();//Model1 : DbContext
            model.Database.ExecuteSqlCommand("alter table Results drop column Total; alter table Results add Total AS (Arabic + English + Math + Science)");
            var r1 = (from s in model.Students
                      join r in model.Results
                      on s.StudentId equals r.StudentId
                      select new { s.StudentName, r.Arabic, r.English, r.Science, r.Math, r.Total }).ToList();
            dataGridView1.DataSource = r1;
        }
