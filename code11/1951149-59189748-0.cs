    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using System.Web.Mvc;
    
    using ReadingFromDb.Dto;
    
    namespace ReadingFromDb.Controller
    {
        public class StudentController:Controller
        {
            [HttpGet]
            [AllowAnonymous]
            public async Task<JsonResult> GetStudents()
            {
                using (var context = new UNIEntities1())
                {
                    var query = @"Select ";
                    var dbQuery = context.Database.SqlQuery<StudentDto>(query);
                    var list = await dbQuery.ToListAsync();
                    return Json(list,JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
