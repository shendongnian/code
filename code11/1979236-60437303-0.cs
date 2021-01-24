csharp
using ExpressiveAnnotations.Attributes;
public int AnswerId { get; set; }
[RequiredIf(nameof(IsOptional) + " == false")]
public string Answer { get; set; }
public bool IsOptional { get; set; }
