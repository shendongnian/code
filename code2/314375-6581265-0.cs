	public void FetchData(int pageNum)
	{
		Uri address = ...;
		var request = WebRequest.Create(address);
		// ...  init request
		request.BeginGetRequestStream(asyncResp => {
														var response = (WebResponse) request.EndGetResponse(asyncRes);
														ParseAndSave(response, pageNum);
														NUM++;
														if (NUM != TOTAL_NUM)
															FetchData(NUM);
													}, null);																
	}	
