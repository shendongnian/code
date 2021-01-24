    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public enum AttributeType
    {
        maxhp, str, dex, intel, wis,
    }
    [System.Serializable]
    public class Attribute
    {
        public AttributeType WhatAttri;
        public float amount;
        public Attribute(AttributeType type, int a)
        {
            WhatAttri = type;
            amount = a;
        }
    }
    public class LinqTest : MonoBehaviour
    {
     Attribute[] attList1 = new Attribute[3];
     Attribute[] attList2 = new Attribute[3]; 
    void Start()
    {
        attList1[0] = new Attribute(AttributeType.maxhp, 6);
        attList1[1] = new Attribute(AttributeType.str, 4);
        attList1[2] = new Attribute(AttributeType.dex, 3);
        attList2[0] = new Attribute(AttributeType.str, 9);
        attList2[1] = new Attribute(AttributeType.intel, 7);
        attList2[2] = new Attribute(AttributeType.wis, 5);
        Calcul();
    }
    void Calcul()
    {
        var result =
     attList2.Select(a => new Attribute(a.WhatAttri, -(int)a.amount)) // line 1
     .Union(attList1)  // line 2
     .GroupBy(a => a.WhatAttri)  // line 3
     .Select(g => new Attribute(g.Key, g.Sum(a => (int)a.amount)));  // line4
        foreach (var a in result)
        {
            Debug.Log($"{a.WhatAttri}: {a.amount}");
        }
    } 
    }
