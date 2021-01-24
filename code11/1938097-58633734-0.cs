            class ResultAmount
            {
                public string Label { get; set; }
                public decimal SumAmount { get; set; }
    
                public override string ToString()
                {
                    return $"{Label}: {SumAmount}";
                }
            }
