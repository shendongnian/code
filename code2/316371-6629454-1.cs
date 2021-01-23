    foreach (Criteria.SegmentCriteria x in myCriteria)
                {
                    Criteria.SegmentCriteria item = x;
                    if (myMatchMethod == Common.MultipleCriteriaMatchMethod.MatchOnAll)
                    {
                        predicate = predicate.Expand().And<Segment>(CreateCriteriaExpression(item).Expand());
                        customPropertiesPredicate = customPropertiesPredicate.Expand().And<Segment>(CreateCriteriaExpressionForCustomProperties(item).Expand());
                    }
                    else if (myMatchMethod == Common.MultipleCriteriaMatchMethod.MatchOnAny)
                    {
                        predicate = predicate.Expand().Or<Segment>(CreateCriteriaExpression(item).Expand());
                        customPropertiesPredicate = customPropertiesPredicate.Expand().Or<Segment>(CreateCriteriaExpressionForCustomProperties(item).Expand());
                    }
                }
