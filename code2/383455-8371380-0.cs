    <?xml version="1.0" encoding="utf-8" ?>
    
    <!--
    I. Overall
    
    I.1 Each pattern can have <Match>....</Match> element. For the given type declaration, the pattern with the match, evaluated to 'true' with the largest weight, will be used 
    I.2 Each pattern consists of the sequence of <Entry>...</Entry> elements. Type member declarations are distributed between entries
    I.3 If pattern has RemoveAllRegions="true" attribute, then all regions will be cleared prior to reordering. Otherwise, only auto-generated regions will be cleared
    I.4 The contents of each entry is sorted by given keys (First key is primary,  next key is secondary, etc). Then the declarations are grouped and en-regioned by given property
    
    II. Available match operands
    
    Each operand may have Weight="..." attribute. This weight will be added to the match weight if the operand is evaluated to 'true'.
    The default weight is 1
    
    II.1 Boolean functions:
    II.1.1 <And>....</And>
    II.1.2 <Or>....</Or>
    II.1.3 <Not>....</Not>
    
    II.2 Operands
    II.2.1 <Kind Is="..."/>. Kinds are: class, struct, interface, enum, delegate, type, constructor, destructor, property, indexer, method, operator, field, constant, event, member
    II.2.2 <Name Is="..." [IgnoreCase="true/false"] />. The 'Is' attribute contains regular expression
    II.2.3 <HasAttribute CLRName="..." [Inherit="true/false"] />. The 'CLRName' attribute contains regular expression
    II.2.4 <Access Is="..."/>. The 'Is' values are: public, protected, internal, protected internal, private
    II.2.5 <Static/>
    II.2.6 <Abstract/>
    II.2.7 <Virtual/>
    II.2.8 <Override/>
    II.2.9 <Sealed/>
    II.2.10 <Readonly/>
    II.2.11 <ImplementsInterface CLRName="..."/>. The 'CLRName' attribute contains regular expression
    II.2.12 <HandlesEvent />
    -->
