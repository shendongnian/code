	public class GetAllRelatedResourcesByParentGuidQuery :
						IGetAllRelatedResourcesByParentGuidQuery
	{
		public IEnumerable<IDependency> Invoke(
				Guid parentCiId,
				IResoucesByIdQuery getResources)
		{
			var checkedItems = new List<Guid>();
			Func<Guid, IResoucesByIdQuery, IEnumerable<IDependency>> invoke = null;
			invoke = (pcid, gr) =>
			{
				if (!checkedItems.Contains(pcid))
				{
					checkedItems.Add(pcid);
					var drs = gr.Invoke(pcid).ToArray();
					foreach (var relatedResource in drs)
					{
						relatedResource
							.Resource
							.DependentResources =
								invoke(relatedResource.Resource.Id, gr);
					}
					return drs;
				}
				return Enumerable.Empty<IDependency>();
			};
		}
	}
