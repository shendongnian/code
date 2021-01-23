    [Test]
    public void PrintStudentReport_ClassRoomPassed_StudentListOfFive_WithAAA()
    {
    	//Arrange
    	IClassRoom classRoom = GetClassRoom(); // Gets a class with 5 students
    	IStudentReporter reporter = MockRepository.GenerateMock<IStudentReporter>();
    		
    	//Act
    	reporter.PrintStudentReport(classRoom.Students);
    	
    	//Assert
    	reporter
            .AssertWasCalled(r =>  r.PrintStudentReport(
                            Arg<List<IStudent>>
                                   .List.Count(Is.Equal(5)))
                             );
    }
