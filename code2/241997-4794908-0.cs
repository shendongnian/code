    [TestFixture]
    public class ExcelWorksheetColumnTests
    {
            private const string _name = "F1";
            private const int _index = 0;
    
            private ExcelWorksheetColumn CreateColumnUsingFixtureFieldsButWith(IExcelWorksheet excelWorksheet)
            {
                return new ExcelWorksheetColumn(_name, _index, excelWorksheet);
            }
    
            [Test]
            public void When_SelectedShootColumnType_Is_Changed_Raises_SelectedShootColumnTypeChanged_Event()
            {
                var stubWorksheet = MockRepository.Stub<IExcelWorksheet>();
    
                ExcelWorksheetColumn column =
                    CreateColumnUsingFixtureFieldsButWith(stubWorksheet);
    
                stubWorksheet
                   .Stub(p => p.GetSelectedShootColumnType(column))
                   .Return(ShootColumnType.Generic);
    
                bool itHappened = false;
    
                column.SelectedShootColumnTypeChanged 
                    += (s, e) => { itHappened = true; };
    
                column.SelectedShootColumnType = ShootColumnType.SubjectId;
    
                Assert.That(itHappened);
            }
    }
