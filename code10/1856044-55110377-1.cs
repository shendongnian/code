    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Ebdaa2030.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    public class UsersGroupController : Controller
    {
        private Ebdaa2030DBEntities db = new Ebdaa2030DBEntities();
        private ApplicationUserManager _userManager;
        // GET: UsersGroup
        public ActionResult Index()
        {
            var usersWithRoles = (from user in db.AspNetUsers
                                  from userRole in user.AspNetRoles
                                  join role in db.AspNetRoles on userRole.Id equals
                                  role.Id
                                  select new UsersGroups()
                                  {
                                      Id = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Role = role.Name,
                                      IdRole = role.Id
                                  }).ToList();
            return View(usersWithRoles);
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.UserType = new SelectList(db.AspNetRoles.ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(AspNetUser user, string role)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UserType = new SelectList(db.AspNetRoles.ToList(), "Name", "Name");
                var oldUser = db.AspNetUsers.SingleOrDefault(u => u.Id == user.Id);
                var oldRoleId = oldUser.AspNetRoles.SingleOrDefault().Id;
                var oldRoleName = db.AspNetRoles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                if (oldRoleName != role)
                {
                    UserManager.RemoveFromRole(user.Id, oldRoleName);
                    UserManager.AddToRole(user.Id, user.UserType);
                }
                UserManager.AddToRoleAsync(user.Id, user.UserType);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
 
