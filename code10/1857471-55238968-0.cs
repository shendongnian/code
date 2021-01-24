    	using D2Chess.Server.IO;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	namespace D2Chess.Controllers
	{
		[Route("api/[controller]/[action]")]
		public class WebController : Controller
		{
			#region Init
			private JsonSerializer jsonSerializer = new JsonSerializer();
			private Repository repository = new Repository();
			public WebController(IHubContext<D2Chess.Server.IO.Hub> hubContext) { D2Chess.Server.IO.Hub.StaticContext = hubContext; }
			#endregion
			#region Classes
			public class Parms {
				public Guid? TokenId { get; set; }
				public string Action { get; set; }
				public object Data { get; set; }
			}
			public class Result
			{
				public bool Success { get; set; }
				public object Data { get; set; }
				public Result(bool pSuccess, object pData = null) { this.Success = pSuccess; this.Data = pData; }
			}
			#endregion
			#region Sync Methods
			[HttpGet]
			public object Get(string pAction, string pKey = "", Guid? pTokenId = null)
			{
				return repository.WebGet(pAction, pKey, pTokenId);
				//var result = repository.WebGet(pAction, pKey, pTokenId);
				//return result;
			}
			[HttpPost]
			public object Post([FromBody] object pParms)
			{
				var parms = ((JObject)pParms).ToObject<Parms>();
				return repository.WebPost(parms.Action, parms.Data, parms.TokenId);
				//var result = repository.WebPost(parms.Action, parms.Data, parms.TokenId);
				//return result;
			}
			#endregion
		}
	}
