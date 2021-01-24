    	using DMChess_Data.Model;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.Text;
	using System.Threading.Tasks;
	namespace DMChess_Data
	{
		public class Entities
		{
			private dmchessContext DMCConnection = new dmchessContext();
			private Guid AppId = new Guid("B6C093C8-AE8C-40CD-9E0D-3BD2118422EC");
			public bool SaveChanges()
			{
				try
				{
					DMCConnection.SaveChangesAsync();
				}
				catch(Exception pException)
				//catch (Microsoft.EntityFrameworkCore.)
				//catch (System.Data.Entity.Validation.DbEntityValidationException ex)
				{
					var ex = pException;
					//foreach (var eve in ex.EntityValidationErrors)
					//{
					//    var type = eve.Entry.Entity.GetType().Name;
					//    var state = eve.Entry.State;
					//    foreach (var ve in eve.ValidationErrors)
					//    {
					//        var propertyName = ve.PropertyName;
					//        var ErrorMessage = ve.ErrorMessage;
					//    }
					//}
					//var m = ex;
					throw;
				}
				DMCConnection.SaveChanges();
				return true;
			}
			#region AUsers
			public AUsers AUsersGet(Guid pId, string pPassword)
			{
				return DMCConnection.AUsers.FirstOrDefault(x => x.KAppId == AppId && x.KId == pId && x.Password == pPassword);
			}
			public AUsers AUsersGet(string pEmailAddress, string pPassword)
			{
				return DMCConnection.AUsers.FirstOrDefault(x => x.KAppId == AppId && x.EmailAddress == pEmailAddress);
			}
			#endregion
			#region DProfiles
			public DProfiles DProfileGet(Guid pKUserId, int pKIdx)
			{
				return DMCConnection.DProfiles.FirstOrDefault(x => x.KAppId == AppId && x.KUserId == pKUserId && x.KIdx == pKIdx);
			}
			public List<DProfiles> DProfilesGet(string pUserIdName)
			{
				return DMCConnection.DProfiles.Where(x => x.KAppId == AppId && x.UserIdToLower == pUserIdName.ToLower()).ToList();
			}
			#endregion
		}
	}
