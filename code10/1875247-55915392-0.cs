    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestProjectMvc.Controllers;
    
    namespace TestProjectMvc.Tests
    {
    	[TestClass]
    	public class MemberControllerTests
    	{
    		[TestMethod]
    		public void CreateUpdateTest()
    		{
    			ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
    			TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
    			ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());
    
    			MemberController controller = new MemberController(new UnitOfWork())
    			{
    				TempData = tempData
    			};
    
    			ViewResult viewResult = controller.CreateUpdate(null) as ViewResult;
    
    			Assert.IsFalse((bool)viewResult.TempData["EditMember"]);
    
    			viewResult = controller.CreateUpdate("123") as ViewResult;
    
    			Assert.IsTrue((bool)viewResult.TempData["EditMember"]);
    		}
    	}
    }
