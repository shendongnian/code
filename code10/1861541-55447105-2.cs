    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using ICTAdministration.Models;
    
    namespace ICTAdministration.Controllers
    {
        [ICTAuthorise]
        public class TeamsController : Controller
        {
            private ICTEntities db = new ICTEntities();
    
            public TeamsController()
            {
            }
    
            public TeamsController(ICTEntities ictEntitiesDB)
            {
                if (ictEntitiesDB != null) db = ictEntitiesDB;
            }
    
            // GET: Teams
            public ViewResult Index()
            {
                var teams = from t in db.Teams.Include(t => t.CreatedBy).Include(t => t.ModifiedBy)
                            select t;
                
                return View(teams);
            }
    
            private void SetAuditFields(Team team, bool onlyModified = false)
            {
                //Set the audit fields - TODO make this generic, its tricky as we dont have multiple inheritance in C# and doing this via an Interface isn't good design - meh KISS for Bern
                char sep = '\\';
                string pID = User.Identity.Name.Split(sep)[1];
                var currentUser = db.Employees.FirstOrDefault(c => c.EmployeeADID == pID);
    
                if (onlyModified)
                {
                    var originalEmployee = from e in db.Employees
                                           join t in db.Teams on e.EmployeeID equals t.CreatedByID
                                           where t.TeamID == team.TeamID
                                           select new { e.EmployeeID, t.CreatedDate };
    
                    //SQL above query was based on
                    //select * from teams t
                    //inner join employees e on e.EmployeeID = t.CreatedByID
                    //where
                    //t.TeamID = 1
                    
                    team.CreatedByID = originalEmployee.ToList()[0].EmployeeID;
                    team.CreatedDate = originalEmployee.ToList()[0].CreatedDate;
                    team.ModifiedByID = currentUser.EmployeeID;
                    team.ModifiedDate = DateTime.Now;
                }
                else
                {
                    team.CreatedByID = currentUser.EmployeeID;
                    team.CreatedDate = DateTime.Now;
                    team.ModifiedByID = currentUser.EmployeeID;
                    team.ModifiedDate = DateTime.Now;
                }
            }
    
            // GET: Teams/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Team team = db.Teams.Find(id);
                if (team == null)
                {
                    return HttpNotFound();
                }
                return View(team);
            }
    
            // GET: Teams/Create
            public ActionResult Create()
            {
                return View();
            }
    
            // POST: Teams/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "TeamID,Name,Description,IsCreator,IsImplementor,NotificationFrequency")] Team team)
            {
                if (ModelState.IsValid)
                {
                    //Only unique employee IDs
                    var existingTeam = db.Teams.FirstOrDefault(o => o.Name == team.Name);
                    if (existingTeam != null)
                    {
                        ViewBag.Error = "Team name must be unique, this team (" + existingTeam.Name + ") already exists in the system.";
                        return View(existingTeam);
                    }
    
                    SetAuditFields(team);
                    db.Teams.Add(team);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(team);
            }
    
            // GET: Teams/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Team team = db.Teams.Find(id);
                if (team == null)
                {
                    return HttpNotFound();
                }
                return View(team);
            }
    
            // POST: Teams/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "TeamID,Name,Description,IsCreator,IsImplementor,NotificationFrequency")] Team team)
            {
                if (ModelState.IsValid)
                {
                    var existingTeam = db.Teams.FirstOrDefault(o => o.Name == team.Name && o.TeamID != team.TeamID);
                    if (existingTeam != null)
                    {
                        ViewBag.Error = "Team name must be unique, this team (" + existingTeam.Name + ") already exists in the system.";
                        return View(existingTeam);
                    }
    
                    //Need to fetch object from dB so we can update it - this avoids setting the dB in EntityState.Modified.
                    //Using the EntityState.Modified causes problems when we update the Audit fields , as we need to get the Employees using AsNoTracking(), 
                    //that then makes unit testing it impossible because you cant Mock Employee's and Mock Employees.AsNoTracking
                    var editTeam = db.Teams.FirstOrDefault(o => o.TeamID == team.TeamID);
    
                    editTeam.Name = team.Name;
                    editTeam.Description = team.Description;
                    editTeam.IsCreator = team.IsCreator;
                    editTeam.IsImplementor = team.IsImplementor;
                    editTeam.NotificationFrequency = team.NotificationFrequency;
                    
                    SetAuditFields(editTeam, true);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(team);
            }
            
            //// GET: Teams/Delete/5
            //public ActionResult Delete(int? id)
            //{
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    Team team = db.Teams.Find(id);
            //    if (team == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    return View(team);
            //}
    
            //// POST: Teams/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public ActionResult DeleteConfirmed(int id)
            //{
            //    Team team = db.Teams.Find(id);
    
    
            //    db.Entry(team).State = EntityState.Modified;
            //    SetAuditFields(team, true);
    
    
            //    //This logically deletes
            //    team.IsDeleted = true;
    
            //    //This pysically deletes
            //    //db.Teams.Remove(team);
    
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
    
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
    
    
    
    using ICTAdministration.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Configuration;
    using System.Net;
    using System.Web.Mvc;
    
    namespace ICTAdministration.Controllers.Tests
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        [TestClass()]
        public class TeamsControllerTests : BaseTest
        {
            #region "Index"
    
            [TestMethod()]
            public void TeamsCtrl_IndexTest()
            {
                // Arrange 
                TeamsController controller = new TeamsController(new ICTEntities());
    
                // Act
                ViewResult result = controller.Index() as ViewResult;
    
                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model);
                Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
    
            #endregion 
    
            #region "Details"
    
            [TestMethod()]
            public void TeamsCtrl_DetailsTest()
            {
                // Arrange 
                TeamsController controller = new TeamsController(new ICTEntities());
    
                // Act
                ViewResult result = controller.Details(1) as ViewResult;
    
                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model);
                Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
    
            [TestMethod()]
            public void TeamsCtrl_DetailsTest_ShouldFail_BadRequest()
            {
                // Arrange 
                TeamsController controller = new TeamsController();
    
                // Act
                var result = controller.Details(null);
                var badReqResult = result as HttpStatusCodeResult;
    
                // Assert
                Assert.IsNotNull(badReqResult);
                Assert.AreEqual(Enum.GetName(typeof(HttpStatusCode), badReqResult.StatusCode), HttpStatusCode.BadRequest.ToString());
            }
    
            [TestMethod()]
            public void TeamsCtrl_DetailsTest_ShouldFail_HttpNotFound()
            {
                // Arrange 
                TeamsController controller = new TeamsController(new ICTEntities());
    
                // Act
                var result = controller.Details(-1);
                var httpNotFoundResult = result as HttpNotFoundResult;
    
                // Assert
                Assert.IsNotNull(httpNotFoundResult);
                Assert.IsTrue(Enum.GetName(typeof(HttpStatusCode), httpNotFoundResult.StatusCode) == HttpStatusCode.NotFound.ToString());
            }
    
            #endregion
    
            #region "Create"
    
            [TestMethod()]
            public void TeamsCtrl_CreateTest()
            {
                // Arrange 
                TeamsController controller = new TeamsController(new ICTEntities());
    
                // Act
                ViewResult result = controller.Create() as ViewResult;
    
                // Assert  
                Assert.IsNotNull(result);
            }
            
            [TestMethod()]
            public void TeamsCtrl_CreateSubmitTest_ItemExists()
            {
                // Arrange
                var mockContext = new Mock<ICTEntities>();
                var TeamExists = new Team { TeamID = 1, Name = "Capital Markets", NotificationFrequency = "Immediate" };
                var teamMock = base.GetQueryableMockDbSet(TeamExists);
                mockContext.Setup(m => m.Teams).Returns(teamMock);
    
                TeamsController controller = new TeamsController(mockContext.Object)
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                //Act
                ViewResult result = controller.Create(TeamExists) as ViewResult;
    
                // Assert  
                Assert.IsNotNull(result);
                Assert.IsTrue(result.ViewBag.Error == "Team name must be unique, this team (Capital Markets) already exists in the system.");
            }
    
            [TestMethod()]
            public void TeamsCtrl_CreateSubmitTest()
            {
                // Arrange
                var TeamAdmin = new Team { TeamID = 1, Name = "Capital Markets", NotificationFrequency="Immediate" };
                var TeamNew = new Team { TeamID = 10, Name = "A New Markets", NotificationFrequency = "Immediate" };
    
                var mockContext = new Mock<ICTEntities>();
                var TeamAdminMock = base.GetQueryableMockDbSet(TeamAdmin);
                mockContext.Setup(m => m.Teams).Returns(TeamAdminMock);
    
                // Arrange
               var employeeAdmin = new Employee { TeamID = 1, EmployeeID = 1, CreatedByID=1, FirstName = "Bern", MiddleName = "", LastName = "O", EmployeeADID = EmployeeADIDToRunUnitTests, EmailAddress = "Bern", IsDeleted = false, IsAdministrator = true };
               var employeeAdminMock = base.GetQueryableMockDbSet(employeeAdmin);
                mockContext.Setup(m => m.Employees).Returns(employeeAdminMock);
    
                //I dont want to save it to the Database, otherwise next time we run this the object will already exist, so I mock the call
                mockContext.Setup(d => d.SaveChanges()).Returns(1);
    
                var controller = new TeamsController(mockContext.Object)
                {
                    ControllerContext = base.MockAccess().Object
                };
                RedirectToRouteResult result = null;
    
                // Act
                result = controller.Create(TeamNew) as RedirectToRouteResult;
    
                // Assert 
                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.RouteValues["Action"]);
            }
    
            #endregion
    
            #region "Edit"
    
            [TestMethod()]
            public void TeamsCtrl_EditViewTest()
            {
                // Arrange 
                TeamsController controller = new TeamsController
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                // Act
                ViewResult result = controller.Edit(1) as ViewResult;
    
                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model);
                Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            }
    
            [TestMethod()]
            public void TeamsCtrl_EditTest_ShouldFail_BadRequest()
            {
                // Arrange 
                TeamsController controller = new TeamsController
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                // Act
                var result = controller.Edit((int?)null);
                var badReqResult = result as HttpStatusCodeResult;
    
                // Assert
                Assert.IsNotNull(badReqResult);
                Assert.AreEqual(Enum.GetName(typeof(HttpStatusCode), badReqResult.StatusCode), HttpStatusCode.BadRequest.ToString());
            }
    
            [TestMethod()]
            public void TeamsCtrl_EditTest_ShouldFail_HttpNotFound()
            {
                // Arrange 
                TeamsController controller = new TeamsController
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                // Act
                var result = controller.Edit(-1); 
                var httpNotFoundResult = result as HttpNotFoundResult;
    
                // Assert
                Assert.IsNotNull(httpNotFoundResult);
                Assert.IsTrue(Enum.GetName(typeof(HttpStatusCode), httpNotFoundResult.StatusCode) == HttpStatusCode.NotFound.ToString());
            }
    
            [TestMethod()]
            public void TeamsCtrl_EditSubmitTest()
            {
                // Arrange 
                string EmployeeADIDToRunUnitTests = ConfigurationManager.AppSettings["EmployeeADIDToRunUnitTests"];
                var TeamToDoesntExist = new Team { TeamID = 1 };
                var TeamToEdit = new Team { TeamID = 1, Name = "New Markets", NotificationFrequency = "Immediate", CreatedByID = 1 };
                var currentUser = new Employee { TeamID = 1, EmployeeID = 1, CreatedByID=1, FirstName = "Bern", MiddleName = "", LastName = "O", EmployeeADID = EmployeeADIDToRunUnitTests, EmailAddress = "Bern", IsDeleted = false, IsAdministrator = true };
    
                var mockContext = new Mock<ICTEntities>();
    
                var TeamToDoesntExistMockCU = base.GetQueryableMockDbSet(TeamToDoesntExist);
                var TeamToEditMockCU = base.GetQueryableMockDbSet(TeamToEdit);
                var EmployeeMockCU = base.GetQueryableMockDbSet(currentUser);   
    
                //Using a counter I can chain mocks together
                int callCounter = 1;
                mockContext.Setup(m => m.Teams)
                    .Returns(() =>
                    {
                        if (callCounter == 1)
                        {
                            callCounter++;
                            return TeamToDoesntExistMockCU;
                        }
                        else
                        {
                            return TeamToEditMockCU;
                        }
                    });
    
                mockContext.Setup(m => m.Employees).Returns(EmployeeMockCU);
    
                //I dont want to save it to the Database, otherwise next time we run this the object will already exist, so I mock the call
                mockContext.Setup(d => d.SaveChanges()).Returns(1);
    
                var controller = new TeamsController(mockContext.Object)
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                // Act
                RedirectToRouteResult result = controller.Edit(TeamToEdit) as RedirectToRouteResult;
    
                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Index", result.RouteValues["Action"]);
            }
    
            [TestMethod()]
            public void TeamsCtrl_EditSubmitTest_InvalidModel()
            {
                // Arrange 
                var mockContext = new Mock<ICTEntities>();
                var team = new Team { TeamID = 0, Name = new String('a', 51), Description = new String('a', 201), NotificationFrequency = new String('a', 51) };
                var teamMock = base.GetQueryableMockDbSet(team);
                mockContext.Setup(m => m.Teams).Returns(teamMock);
    
                var controller = new TeamsController(mockContext.Object)
                {
                    ControllerContext = base.MockAccess().Object
                };
    
                // Act
                base.ValidateModel(controller, team);
                ViewResult result = controller.Edit(team) as ViewResult;
    
                // Assert
                Assert.IsNotNull(result);
                Assert.IsFalse(result.ViewData.ModelState.IsValid);
                Assert.IsTrue(result.ViewData.ModelState.Count == 3);
                Assert.IsTrue(result.ViewData.ModelState["Name"].Errors[0].ErrorMessage == "Team name cannot be longer than 50 characters.");
                Assert.IsTrue(result.ViewData.ModelState["Description"].Errors[0].ErrorMessage == "Description cannot be longer than 200 characters.");
                Assert.IsTrue(result.ViewData.ModelState["NotificationFrequency"].Errors[0].ErrorMessage == "Notification Frequency cannot be longer than 50 characters.");
            }
    
            #endregion
    
            //#region "Delete"
    
            //[TestMethod()]
            //public void TeamsCtrl_DeleteViewTest()
            //{
            //    // Arrange 
            //    TeamsController controller = new TeamsController();
            //    controller.ControllerContext = base.MockAccess().Object;
    
            //    // Act
            //    ViewResult result = controller.Delete(1) as ViewResult; //Hard-Coding the ID isn't good, we shoudl look it up
    
            //    // Assert
            //    Assert.IsNotNull(result);
            //    Assert.IsNotNull(result.Model); // add additional checks on the Model
            //    Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            //}
    
            //[TestMethod()]
            //public void TeamsCtrl_DeleteTest_ShouldFail_BadRequest()
            //{
            //    // Arrange 
            //    TeamsController controller = new TeamsController();
            //    controller.ControllerContext = base.MockAccess().Object;
    
            //    // Act
            //    var result = controller.Delete((int?)null);
            //    var badReqResult = result as HttpStatusCodeResult;
    
            //    // Assert
            //    Assert.IsNotNull(badReqResult);
            //    Assert.AreEqual(Enum.GetName(typeof(HttpStatusCode), badReqResult.StatusCode), HttpStatusCode.BadRequest.ToString());
            //}
    
            //[TestMethod()]
            //public void TeamsCtrl_DeleteTest_ShouldFail_HttpNotFound()
            //{
            //    // Arrange 
            //    TeamsController controller = new TeamsController();
            //    controller.ControllerContext = base.MockAccess().Object;
    
            //    // Act
            //    var result = controller.Delete(-1); //Hard-Coding the ID isn't good, we shoudl look it up
            //    var httpNotFoundResult = result as HttpNotFoundResult;
    
            //    // Assert
            //    Assert.IsNotNull(httpNotFoundResult);
            //    Assert.IsTrue(Enum.GetName(typeof(HttpStatusCode), httpNotFoundResult.StatusCode) == HttpStatusCode.NotFound.ToString());
            //}
    
            //[TestMethod()]
            //public void TeamsCtrl_DeleteSubmitTest()
            //{
            //    // Arrange 
            //    string EmployeeADIDToRunUnitTests = ConfigurationManager.AppSettings["EmployeeADIDToRunUnitTests"];
            //    var TeamToDelete = new Team { TeamID = 1, FirstName = "Bern", MiddleName = "", LastName = "O\'Mally", TeamADID = EmployeeADIDToRunUnitTests, EmailAddress = "Bernard.O\'Mally@nab.com.au", TeamID = 1, IsDeleted = false, IsAdministrator = true };
            //    var currentUser = new Team { TeamADID = EmployeeADIDToRunUnitTests, TeamID = 140 };
    
            //    var mockContext = new Mock<ICTEntities>();
            //    var TeamToDeleteMockCU = base.GetQueryableMockDbSet(TeamToDelete);
            //    var TeamMockCU = base.GetQueryableMockDbSet(currentUser);
    
            //    //Mock use a SetupSequence - doesn't work after first mock
            //    //mockContext.SetupSequence(x => x.Teams)
            //    //.Returns(TeamToDeleteMockCU)
            //    //.Returns(TeamMockCU);
    
            //    //Using a counter I can chain mocks together
            //    int callCounter = 1;
            //    mockContext.Setup(m => m.Teams)
            //        .Returns(() =>
            //        {
            //            if (callCounter == 1)
            //            {
            //                callCounter++;
            //                return TeamToDeleteMockCU;
            //            }
            //            else
            //            {
            //                return TeamMockCU;
            //            }
            //        });
    
    
            //    //I dont want to save it to the Database, otherwise next time we run this the object will already exist, so I mock the call
            //    mockContext.Setup(d => d.SaveChanges()).Returns(1);
    
            //    var controller = new TeamsController(mockContext.Object);
            //    controller.ControllerContext = base.MockAccess().Object;
    
    
            //    // Act
            //    RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;
    
            //    // Assert
            //    Assert.IsNotNull(result);
            //    Assert.AreEqual("Index", result.RouteValues["Action"]);
    
            //}
    
            //#endregion
        }
    }
