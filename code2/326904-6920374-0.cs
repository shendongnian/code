        [Test]
        public void TestDeleteAssignment()
        {
            //add assignment
            var myAssignment = new SAssignment()
            {
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Department = 9000.ToString(),
                EmployeeId = 4342342
            };
            Status addStatus = null;
            var assignment = this.m_personnelService.SaveSAssignment(myAssignment, out addStatus);
            Assert.IsTrue(addStatus.Success);
            var targetAssignmentId = assignment.Id;
            //possibility 1
            Status deleteStatus = null;
            var assignment2 = this.m_personnelService.DeleteSAssignment(targetAssignmentId, out deleteStatus);
            Assert.IsTrue(deleteStatus.Success); //or Assert.AreEqual(assignment2.Id, targetAssignmentId);
            //possibility 2
            Status deleteStatus = null;
            var assignment3 = this.m_personnelService.DeleteSAssignment(targetAssignmentId);
            var result = this.m_personnelService.GetSAssignment(targetAssignmentId);
            Assert.IsNull(result);
        }
