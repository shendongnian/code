    void Main()
    {
	Adjustment a1 = new Adjustment {Amount = 12.0M, IsCompounded = false, Add = false, Percent = false};
	Adjustment a2 = new Adjustment {Amount = 3.0M, IsCompounded = true, Add = true, Percent = true};
	Adjustment a3 = new Adjustment {Amount = 5.0M, IsCompounded = true,  Add = true ,Percent = true};
	
	List<Adjustment> adjustments = new List<Adjustment>();
	adjustments.Add(a3);
	adjustments.Add(a2);
	adjustments.Add(a1);
	
	decimal total = 103.55987055016181229773462783m;
	decimal adjustedTotal = total;
	decimal nonCompoundValues = 0.0m;
	decimal compoundValues = 1.0m;
	string prevType = "";
	
	for(int i = 0; i <= adjustments.Count - 1; i++)
	{
		
		if(adjustments[i].Percent)
		{
			if(adjustments[i].IsCompounded)
			{
				
				if(i == adjustments.Count - 1  && adjustments[i].IsCompounded)
				{
					if(adjustments[i].Add)
					{
						nonCompoundValues += adjustments[i].Amount/100.0m;
						
					}
					else
					{
						nonCompoundValues -= adjustments[i].Amount/100.0m;
						
					}
					break;
				}
				
				if(nonCompoundValues < 0  & prevType != "Compound") //Remove tax
				{
					
					adjustedTotal /= compoundValues + Math.Abs(nonCompoundValues);
					nonCompoundValues = 0.0m;
					compoundValues = 1.0m;
					
				}
				else if(nonCompoundValues > 0 & prevType != "Compound") //Add tax
				{
					
					adjustedTotal *= compoundValues + Math.Abs(nonCompoundValues);
					nonCompoundValues = 0.0m;
					compoundValues = 1.0m;
				}
				
				
				if(adjustments[i].Add)
				{
					
					if(prevType == "" || prevType == "Compound")
					{
						adjustedTotal *= 1 + adjustments[i].Amount/100.0m; //add compound first
						compoundValues = 1.0m;
					}
					else
					{
						compoundValues *= 1 + adjustments[i].Amount/100.0m;
					}
				}
				else
				{
					
					if(prevType == "" || prevType == "Compound")
					{
					adjustedTotal /= 1 + adjustments[i].Amount/100.0m;
					
					compoundValues = 1.0m;
					}
					else
					{
						compoundValues /= 1 + adjustments[i].Amount/100.0m;
					}
				}
				
				prevType = "Compound";
				
			}
			else // Non-Compound
			{
			
				if(adjustments[i].Add)
				{
					nonCompoundValues += adjustments[i].Amount/100.0m;
					
				}
				else
				{
					nonCompoundValues -= adjustments[i].Amount/100.0m;
				}
			
				prevType = "Non-compound";
				
			}
			
		}
		else //flat
		{
			if(nonCompoundValues < 0) //Remove tax
				{
					
					adjustedTotal /= compoundValues + Math.Abs(nonCompoundValues);
					nonCompoundValues = 0.0m;
					compoundValues = 1.0m;
					
				}
				else if(nonCompoundValues > 0) //Add tax
				{
					
					adjustedTotal *= compoundValues + Math.Abs(nonCompoundValues);
					nonCompoundValues = 0.0m;
					compoundValues = 1.0m;
				}
			
			if(adjustments[i].Add)
			{
				adjustedTotal += adjustments[i].Amount;
			}
			else
			{
				adjustedTotal -= adjustments[i].Amount;
			}
				
		}
	}
	
	if(nonCompoundValues < 0)
	{
		adjustedTotal /= compoundValues + Math.Abs(nonCompoundValues);
	}
	else
	{
		adjustedTotal *=compoundValues + Math.Abs(nonCompoundValues);
	}
	Console.WriteLine(adjustedTotal);
	
    }
    public class Adjustment
    {
	public bool Percent {get;set;}
	public decimal Amount {get;set;}
	public bool IsCompounded {get;set;}
	public bool Add{get;set;}
	public decimal AmountFraction
	{
	get {
		return Amount/100.0M;
	}
	}
	public decimal CompoundedValue
	{
		get{
			return 1 + AmountFraction;
		}
	}
    }
