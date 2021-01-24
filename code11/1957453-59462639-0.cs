c#
Expression<Func<X,TagGroup>> template = x => 
        new TagGroup { x?.Tag.FirstArtist, x?.Tag.Title, ... };
public Filter : ExpressionVisitor{
    public Filter(... selection){ ... }
    protected override Expression VisitMemberInit(MemberInitExpression node){
        return node.Update(node.NewExpression, node.Bindings.Where( ... ));
    }
}
var groupBy = new Filter(selection).Visit(template);
Filling in the blanks left as an exercise.
