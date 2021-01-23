    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PostSharp.Extensibility;
    using PostSharp.Aspects;
    using PostSharp.Reflection;
    using System.Xml.Serialization;
    
    namespace ApplyingAttributes
    {
        [MulticastAttributeUsage(MulticastTargets.Field | MulticastTargets.Property,
                                TargetMemberAttributes = MulticastAttributes.Public | MulticastAttributes.Instance)]
        public sealed class AddXmlIgnoreAttribute : LocationLevelAspect, IAspectProvider
        {
            private static readonly CustomAttributeIntroductionAspect customAttributeIntroductionAspect =
                new CustomAttributeIntroductionAspect(
                    new ObjectConstruction(typeof(XmlIgnoreAttribute).GetConstructor(Type.EmptyTypes)));
    
            public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
            {
                LocationInfo memberInfo = (LocationInfo)targetElement;
    
                if (memberInfo.PropertyInfo.IsDefined(typeof(XmlElementAttribute), false) ||
                    memberInfo.PropertyInfo.IsDefined(typeof(XmlAttributeAttribute), false))
                    yield break;
    
                yield return new AspectInstance(memberInfo.PropertyInfo, customAttributeIntroductionAspect);
            }
        }
    
    }
