    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    static class Program
    {
        static void Main()
        {
            Expression<Func<Message, bool>> exp1 = x => x.mesID == 1;
            var exp2 = Convert<Message, MessageDTO>(exp1);
        }
        static Expression<Func<TTo, bool>> Convert<TFrom, TTo>(Expression<Func<TFrom, bool>> expr)
        {
            Dictionary<Expression,Expression> substitutues = new Dictionary<Expression,Expression>();
            var oldParam = expr.Parameters[0];
            var newParam = Expression.Parameter(typeof(TTo), oldParam.Name);
            substitutues.Add(oldParam, newParam);
            Expression body = ConvertNode(expr.Body, substitutues);
            return Expression.Lambda<Func<TTo,bool>>(body, newParam);
        }
        static Expression ConvertNode(Expression node, IDictionary<Expression, Expression> subst)
        {
            if (node == null) return null;
            if (subst.ContainsKey(node)) return subst[node];
    
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return node;
                case ExpressionType.MemberAccess:
                    {
                        var me = (MemberExpression)node;
                        var newNode = ConvertNode(me.Expression, subst);
                        return Expression.MakeMemberAccess(newNode, newNode.Type.GetMember(me.Member.Name).Single());
                    }
                case ExpressionType.Equal: /* will probably work for a range of common binary-expressions */
                    {
                        var be = (BinaryExpression)node;
                        return Expression.MakeBinary(be.NodeType, ConvertNode(be.Left, subst), ConvertNode(be.Right, subst), be.IsLiftedToNull, be.Method);
                    }
                default:
                    throw new NotSupportedException(node.NodeType.ToString());
            }
        }
    }
    class Message { public int mesID { get; set; } }
    class MessageDTO { public int mesID { get; set; } }
