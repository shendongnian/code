    var uutData = results.Select(x => new UutData
                {
                    UutResultId = x.Id,
                    ...
                }).ToList();
    var stepData = results.SelectMany(x => (x.StepResults == null ? new List<StepResult>() : x.StepResults), (x, s) => new StepData
                    {
                        UutResultId = x.Id,
                        StepResultId = s.Id,
                        ...
                    }).ToList();
    var propData = stepData.SelectMany(s => (s.PropResults == null ? new List<PropResult>() : s.PropResults), (s, p) => new PropData
                {
                    StepResultId = s.StepResultId,
                    PropResultId = p.Id,
                    ...
                }).ToList();
    //... continue getting nested data objects as needed
    var joined = from propStep in (from uutStep in (from uut in uutData
												 join step in stepData on uut.UutId equals step.UutResultId into step2
												 from subStep in step2.DefaultIfEmpty()
												 select new
												 {
													 uut.UutSerialNumber,
													 ...
													 StepName = subStep == null ? "" : subStep.StepName,
													 ...
													 StepResultId = subStep == null ? "" : subStep.StepResultId
												 })
								join prop in propData on uutStep.StepResultId equals prop.StepResultId into prop2
								from subProp in prop2.DefaultIfEmpty()
								select new
								{
									uutStep.UutSerialNumber,
									...
									uutStep.StepResultId,
									PropName = subProp == null ? "" : subProp.PropName,
									...
									PropResultId = subProp == null ? "" : subProp.PropResultId
								})
								//... continue joins as needed for all nested objects generated above
								//appending data from each previous join to carry it all the way through to the final object
								//to get objects back as List<object>, call .ToList() on entire query (use parentheses to encapsulate entire query)
