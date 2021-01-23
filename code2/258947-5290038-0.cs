	public class AliasToFResultTransformer : AliasToBeanResultTransformer
	{
		public AliasToFResultTransformer() : base(typeof(FMatches)) {}
		object IResultTransformer.TransformTuple(object[] tuple, string[] aliases)
		{
			FMatches fm = base.TransformTuple( tuple, aliases ) as FMatches;
			return fm.ToFResult();
		}
		public class FMatches
		{
			public int sc { get; set; }
			public virtual int Mt1ID { get; set; }
			public virtual string Mt1Word { get; set; }
			public virtual int Mt1WordIntervalBeginning { get; set; }
			public virtual int Mt1WordIntervalEnding { get; set; }
			public virtual int Mt2ID { get; set; }
			public virtual string Mt2Word { get; set; }
			public virtual int Mt2WordIntervalBeginning { get; set; }
			public virtual int Mt2WordIntervalEnding { get; set; }
			public FResult ToFResult()
			{
				return new FResult {
					sc = this.sc,
					Match1 = new Match {
						Id = this.Mt1Id,
						Word = this.Mt1Word,
						WordIntervalBeginning = this.Mt1WordIntervalBeginning,
						WordIntervalEnding = this.Mt1WordIntervalEnding
					},
					Match2 = new Match {
						Id = this.Mt2Id,
						Word = this.Mt2Word,
						WordIntervalBeginning = this.Mt2WordIntervalBeginning,
						WordIntervalEnding = this.Mt2WordIntervalEnding
					}
				}
			}
		}
	}
