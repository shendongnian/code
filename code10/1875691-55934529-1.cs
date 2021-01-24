	public static List<BankDepositHistoryItemDto> GetChangeRequestsList(int skip, int take, out int total, string name, string email, AvailableBankDepositStates state)
	{
		var statesFilter = new Dictionary<AvailableBankDepositStates, Func<IQueryable<BankDepositHistory>, IQueryable<BankDepositHistory>>>()
		{
			{ AvailableBankDepositStates.All, bdh => bdh.Where(x => x.State != BankDepositState.Start.ToString()) },
			{ AvailableBankDepositStates.Success, bdh => bdh.Where(x => x.State == AvailableBankDepositStates.Success.ToString()) },
			{ AvailableBankDepositStates.Fail, bdh => bdh.Where(x => x.State == AvailableBankDepositStates.Fail.ToString()) },
		};
		List<string> emails = new List<string>();
		ILookup<string, string> developers = null;
		using (var myketDB = new MyketReadOnlyDb())
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				emails = myketDB.AppDevelopers.Where(n => n.RealName.Contains(name)).Select(e => e.Email).ToList();
			}
			developers = myketDB.AppDevelopers.ToLookup(x => x.Email, x => x.RealName);
		}
		using (var myketAdsDB = new MyketAdsEntities())
		{
			var bankDepositHistories = myketAdsDB.BankDepositHistories.AsQueryable();
			if (emails.Count() > 0)
			{
				bankDepositHistories = bankDepositHistories.Where(e => emails.Contains(e.AccountId));
			}
			if (!string.IsNullOrWhiteSpace(email))
			{
				bankDepositHistories = bankDepositHistories.Where(a => a.AccountId.Contains(email));
			}
			bankDepositHistories = statesFilter[state](bankDepositHistories);
			total = bankDepositHistories.Count();
			var result =
				bankDepositHistories
					.OrderByDescending(ba => ba.CreationDate)
					.Skip(skip)
					.Take(take)
					.ToList()
					.Select(b => new BankDepositHistoryItemDto()
					{
						Id = b.Id,
						AccountId = b.AccountId,
						Amount = b.Amount,
						ClientIp = b.ClientIp,
						State = (BankDepositState)Enum.Parse(typeof(BankDepositState), b.State, true),
						ReturnUrl = b.ReturnUrl,
						AdditionalData = b.AdditionalData,
						Gateway = b.Gateway,
						CreationDate = b.CreationDate,
						PaymentRefNumber = b.PaymentRefNumber,
						Uuid = b.Uuid,
						RealName = developers[b.AccountId].LastOrDefault(),
					}).ToList();
			return result;
		}
	}
