using System;
using System.Collections.Generic;
using System.Linq;
                    
public class Program
{
    public static void Main()
    {            
        var attributes = new Attribute[] {
            new Attribute{WhatAttri=AttributeType.maxhp, amount=6 },
            new Attribute{WhatAttri=AttributeType.str, amount=4 },
            new Attribute{WhatAttri=AttributeType.dex, amount=3 },
        };
        //Attribute modifier has to be either positive or negative
        var attributesModifier = new Attribute[] {
            new Attribute{WhatAttri=AttributeType.str, amount=-9 },
            new Attribute{WhatAttri=AttributeType.@int, amount=-7 },
            new Attribute{WhatAttri=AttributeType.wis, amount=-5 },
        };
        var newAttributes = attributes
                                .Concat(attributesModifier)
                                .GroupBy(x => x.WhatAttri)
                                .Select(group => 
                                        new Attribute { 
                                            WhatAttri = group.Key, 
                                            amount = group.Sum(g => g.amount) 
                                        });
        
        
        newAttributes.Dump();
    }
    
    public class Attribute
    {
        public AttributeType WhatAttri { get; set; }
        public float amount { get; set; }
    }
    public enum AttributeType
    {
        maxhp, str, dex, @int, wis
    }
}
OnLine demo https://dotnetfiddle.net/3C7n7F
