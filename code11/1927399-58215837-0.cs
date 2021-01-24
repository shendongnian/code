    private bool GenerateElement(XmlSchemaElement e, bool root, InstanceGroup parentElem, XmlSchemaAny any) {
             XmlSchemaElement eGlobalDecl = e;
             bool flagCached = false;
             if (!e.RefName.IsEmpty) {
                   eGlobalDecl = (XmlSchemaElement)schemaSet.GlobalElements[e.QualifiedName];
             }
             if (!eGlobalDecl.IsAbstract) {
                   InstanceElement elem = (InstanceElement)elementTypesProcessed[eGlobalDecl];
                   if (elem != null) {
                       Debug.Assert(!root);
                       if (any == null && e.MinOccurs > 0) { //If not generating for any or optional ref to cyclic global element
                           decimal occurs = e.MaxOccurs;
                           if (e.MaxOccurs >= maxThreshold) {
                               occurs = maxThreshold;
                           }
                           if (e.MinOccurs > occurs) {
                               occurs = e.MinOccurs;
                           }
                           elem = elem.Clone(occurs);
                           parentElem.AddChild(elem);
                           flagCached = true;
                       }
                   }
                   else
                   {
                       elem = new InstanceElement(eGlobalDecl.QualifiedName);
                   }
                   if(root) {
                       instanceRoot = elem;
                   }
                   else {
                       if(!flagCached)
                       parentElem.AddChild(elem);
                       flagCached = false;
                   }
                   //Get minOccurs, maxOccurs alone from the current particle, everything else pick up from globalDecl
                   if (any != null) { //Element from any
                       elem.Occurs = any.MaxOccurs >= maxThreshold ? maxThreshold : any.MaxOccurs;
                       elem.Occurs = any.MinOccurs > elem.Occurs ? any.MinOccurs : elem.Occurs;
                   }
                   else {
                       elem.Occurs = e.MaxOccurs >= maxThreshold ? maxThreshold : e.MaxOccurs;
                       elem.Occurs = e.MinOccurs > elem.Occurs ? e.MinOccurs : elem.Occurs;
                   }
                   elem.DefaultValue = eGlobalDecl.DefaultValue;
                   elem.FixedValue = eGlobalDecl.FixedValue;
                   elem.IsNillable = eGlobalDecl.IsNillable;
                   if (eGlobalDecl.ElementSchemaType == AnyType) {
                       elem.ValueGenerator = XmlValueGenerator.AnyGenerator;
                   }
                   else {
                       XmlSchemaComplexType ct = eGlobalDecl.ElementSchemaType as XmlSchemaComplexType;
                       if (ct != null) {
                           if(!elementTypesProcessed.ContainsKey(eGlobalDecl)) elementTypesProcessed.Add(eGlobalDecl, elem);
                           if (!ct.IsAbstract) {
                               elem.IsMixed = ct.IsMixed;
                               ProcessComplexType(ct, elem);
                           }
                           else { // Ct is abstract, need to generate instance elements with xsi:type
                               XmlSchemaComplexType dt = GetDerivedType(ct);
                               if (dt != null) {
                                   elem.XsiType = dt.QualifiedName;
                                   ProcessComplexType(dt, elem);
                               }
                           }
                       }
                       else { //elementType is XmlSchemaSimpleType
                           elem.ValueGenerator = XmlValueGenerator.CreateGenerator(eGlobalDecl.ElementSchemaType.Datatype, listLength);
                       }
                   }
                   if (elem.ValueGenerator != null && elem.ValueGenerator.Prefix == null) {
                       elem.ValueGenerator.Prefix = elem.QualifiedName.Name;
                   }
                   return true;
             } // End of e.IsAbstract
             return false;
           }
