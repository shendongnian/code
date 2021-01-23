    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Web;  
    using System.ServiceModel.Description;  
    using System.Xml.Schema;  
    using System.Workflow.Activities.Rules;  
    using System.Workflow.ComponentModel.Serialization;  
    namespace ServiceMediation.Behaviors  
    {  
        public class TransformingMessageServiceBehavior : IServiceBehavior  
        {  
            private string _ruleSetPath = null;  
            private RuleSet _ruleSet = null;  
            public TransformingMessageServiceBehavior(string ruleSet)
            {
                if (!string.IsNullOrWhiteSpace(ruleSet))
                {
                    _ruleSetPath = ruleSet;
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    XmlTextReader reader = new XmlTextReader(_ruleSetPath);
                    RuleDefinitions rules = serializer.Deserialize(reader) 
                        as RuleDefinitions;
                    _ruleSet = rules.RuleSets[0];
                }
            }
    ...
