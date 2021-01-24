`csharp
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq; //I'm running Moq 4.13 
namespace UnitTestProject1
{
    public class DimensionStructure
    {
        public long Id { get; set; }
    }
    public interface ITest
    {
        Task<DimensionStructure> GetDimensionStructureByIdAsync(DimensionStructure dimensionStructure);
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var addedToRoot = new DimensionStructure { Id = 1 };
            var addedToFirstLevel = new DimensionStructure { Id = 2 };
            var _masterDataWebApiClientMock = new Mock<ITest>();
            _masterDataWebApiClientMock.Setup(m => m.GetDimensionStructureByIdAsync(
                    It.Is<DimensionStructure>(
                        structure => structure.Id == 101)
                ))
                .ReturnsAsync(addedToRoot);
            _masterDataWebApiClientMock.Setup(m => m.GetDimensionStructureByIdAsync(
                    It.Is<DimensionStructure>(
                        structure => structure.Id == 201)
                ))
                .ReturnsAsync(addedToFirstLevel);
            Assert.AreEqual(1, _masterDataWebApiClientMock.Object.GetDimensionStructureByIdAsync(new DimensionStructure { Id = 101 }).Result.Id);
            Assert.AreEqual(2, _masterDataWebApiClientMock.Object.GetDimensionStructureByIdAsync(new DimensionStructure { Id = 201 }).Result.Id);
        }
    }
}
`
