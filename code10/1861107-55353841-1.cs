C#
	protected async Task<TestRequestResponse> PostAsync<TPayload>(string url, TPayload payload, string token = null)
		{
			using (var server = new HttpServer(_config))
			{
				var client = new HttpClient(server);
				var request = new HttpRequestMessage
				{
					RequestUri = new Uri(url),
					Method = HttpMethod.Post,
					Content = new ObjectContent<TPayload>(payload, new JsonMediaTypeFormatter())
				};
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				request.Headers.Add("token", token);
				
				var httpRequest = new HttpRequest(string.Empty, url, string.Empty);
				httpRequest.AddServerVariable("UserHostAddress", "192.168.1.1");
				httpRequest.AddServerVariable("UserAgent", "chrome");
				HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new StringWriter()));
				using (var response = await client.SendAsync(request))
				{
					var streamContent = await response.Content.ReadAsStreamAsync();
					var memoryStream = new MemoryStream();
					streamContent.CopyTo(memoryStream);
					memoryStream.Position = 0;
					var content = await response.Content.ReadAsStringAsync();
					return new TestRequestResponse
					{
						Content = content,
						StatusCode = response.StatusCode,
						Message = response.ReasonPhrase,
						StreamContent = memoryStream
					};
				}
			}
		}
C#
		[Theory]
		[MemberData(nameof(DataForTrySaveInExcelFileTesting))]
		public async Task Should_ReturnCode200TrySaveDataInFileExcel(DownloadRequest request)
		{
			// Arrange
			var token = await GetValidTokenAsync();
			// Act
			var responseBilling = await ActAsync<DownloadRequest, Record>(request, token, DownloadUrl);
			var excelFile = ExcelFile.Load(response.StreamContent, LoadOptions.XlsxDefault);
			var ws = excelFile.Worksheets.ActiveWorksheet;
			ws.Cells["E2"].Value.ShouldBeEqualTo("11111");
			ws.Cells["Q3"].Value.ShouldBeEqualTo("11111");
			ws.Cells["C4"].Value.ShouldBeEqualTo(11111);
			ws.Cells["F5"].Value.ShouldBeEqualTo("11111");
			ws.Cells["O6"].Value.ShouldBeEqualTo("11111");
			ws.Rows.Count.ShouldBeEqualTo(request.Data.Count + 1);
		}
        public async Task<TestRequsetResponse> ActAsync<TRequest, TItem>(TRequest reuqset = null, string token = null, string url = null) where TRequest : DownloadRequest<Item>
        {
            return await PostAsync(url, request, token);
        }
