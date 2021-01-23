    sb.AppendLine(string.Format("\tpublic class {0} : RPG.ComponentModel.IDataRule<{1}>", className, typeName));
                sb.AppendLine("\t{");
                sb.AppendLine("\t\tprivate int _ruleId = -1;");
                sb.AppendLine("\t\tprivate string _ruleName = \"\";");
                sb.AppendLine("\t\tprivate string _ruleType = \"\";");
                sb.AppendLine("\t\tprivate string _validationMessage = \"\";");
                /// ... 
                sb.AppendLine("\t\tprivate bool _isenabled= false;");
                // constructor
                sb.AppendLine(string.Format("\t\tpublic {0}()", className));
                sb.AppendLine("\t\t{");
                sb.AppendLine(string.Format("\t\t\tRuleId = {0};", ruleId));
                sb.AppendLine(string.Format("\t\t\tRuleName = \"{0}\";", ruleName.TrimEnd()));
                sb.AppendLine(string.Format("\t\t\tRuleType = \"{0}\";", ruleType.TrimEnd()));                
                sb.AppendLine(string.Format("\t\t\tValidationMessage = \"{0}\";", validationMessage.TrimEnd()));
                // ...
                sb.AppendLine(string.Format("\t\t\tSortOrder = {0};", sortOrder));                
                
                sb.AppendLine("\t\t}");
                // properties
                sb.AppendLine("\t\tpublic int RuleId { get { return _ruleId; } set { _ruleId = value; } }");
                sb.AppendLine("\t\tpublic string RuleName { get { return _ruleName; } set { _ruleName = value; } }");
                sb.AppendLine("\t\tpublic string RuleType { get { return _ruleType; } set { _ruleType = value; } }");
                
                /// ... more properties -- omitted
                sb.AppendLine(string.Format("\t\tpublic bool Test({0} entity) ", typeName));
                sb.AppendLine("\t\t{");
                
                sb.AppendLine(string.Format("\t\t\treturn {0};", expressionText.TrimEnd()));
                sb.AppendLine("\t\t}");  // close method
                sb.AppendLine("\t}"); // close Class
