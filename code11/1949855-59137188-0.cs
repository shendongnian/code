        public ActionResult Staff()
        {
            // This would be nice to have as separate Data Access Layery class
            var staffs = GetStaffs();
            return View(staffs);
        }
        private static StaffDto[] GetStaffs()
        {
            // One call to database is better that several
            var staffs = db.master_staff
                .Where(x => x.staff_id > 0) // Any other condition, if needed
                .Select(x => new StaffDto(x.staff_id, x.staff_name))
                .ToArray();
            return staffs;
        }
        // Data Transfer Object class to separate database from presentation view
        public class StaffDto
        {
            public int StaffId { get; set; }
            public string Name { get; set; }
            public StaffDto(int staffId, string name)
            {
                StaffId = staffId;
                Name = name;
            }
        }
