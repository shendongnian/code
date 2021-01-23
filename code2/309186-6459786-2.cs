    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    namespace ValidationHelpers
    {
      [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field , AllowMultiple = false )]
      sealed public class EmailAddressValidationAttribute : ValidationAttribute
      {
        static EmailAddressValidationAttribute()
        {
          RxEmailAddress = CreateEmailAddressRegex();
          return;
        }
        private static Regex CreateEmailAddressRegex()
        {
          // references: RFC 5321, RFC 5322, RFC 1035, plus errata.
          string atom             = @"([A-Z0-9!#$%&'*+\-/=?^_`{|}~]+)"                 ;
          string dot              = @"(\.)"                                            ;
          string dotAtom          =  "(" + atom + "(" + dot + atom + ")*" + ")"        ;
          string dnsLabel         = "([A-Z]([A-Z0-9-]{0,61}[A-Z0-9])?)"                ;
          string fqdn             = "(" + dnsLabel + "(" + dot + dnsLabel + ")*" + ")" ;
          string localPart        = "(?<localpart>" + dotAtom + ")"      ;
          string domain           = "(?<domain>" + fqdn + ")"            ;
          string emailAddrPattern = "^" + localPart + "@" + domain + "$" ;
          Regex instance = new Regex( emailAddrPattern , RegexOptions.Singleline | RegexOptions.IgnoreCase );
          return instance;
        }
        private static Regex RxEmailAddress;
        public override bool IsValid( object value )
        {
          string s      = Convert.ToString( value ) ;
          bool   fValid = string.IsNullOrEmpty( s ) ;
          // we'll take an empty field as valid and leave it to the [Required] attribute to enforce that it's been supplied.
          if ( !fValid )
          {
            Match m = RxEmailAddress.Match( s ) ;
            if ( m.Success )
            {
              string emailAddr              = m.Value ;
              string localPart              = m.Groups[ "localpart" ].Value ;
              string domain                 = m.Groups[ "domain"    ].Value ;
              bool   fLocalPartLengthValid  = localPart.Length >= 1 && localPart.Length <=  64 ;
              bool   fDomainLengthValid     = domain.Length    >= 1 && domain.Length    <= 255 ;
              bool   fEmailAddrLengthValid  = emailAddr.Length >= 1 && emailAddr.Length <= 256 ; // might be 254 in practice -- the RFCs are a little fuzzy here.
              fValid = fLocalPartLengthValid && fDomainLengthValid && fEmailAddrLengthValid ;
            }
          }
          return fValid ;
        }
      }
    }
