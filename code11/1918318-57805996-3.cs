    public List<CourseSearchDetail> GetPaginated(SearchRequest searchRequest, bool admin, out int totalRecords,
			out int recordsFiltered)
		{
			var query = _courseRepo
				.GetDataTableQuery();
			if (!admin) query = query.Where(x => x.CourseDate > DateTime.Now);
			var courseList = query.ToList();
			totalRecords = courseList.Count();
			if (!string.IsNullOrEmpty(searchRequest.Search.Value))
				courseList = courseList.Where(x => x.CourseTitle.ToLower().Contains(searchRequest.Search.Value.ToLower())).ToList();
			recordsFiltered = courseList.Count();
			if (searchRequest.Order == null)
				courseList = courseList.OrderByDescending(x => x.CourseDate).ToList();
			else
				courseList = courseList.OrderResults(searchRequest);
			var skip = searchRequest.Start;
			var pageSize = searchRequest.Length;
			courseList = pageSize > 0
				? courseList.Skip(skip).Take(pageSize).ToList()
				: courseList.ToList();
			return courseList;
		}
