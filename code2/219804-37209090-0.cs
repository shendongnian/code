    using System;
    using System.Diagnostics;
    namespace TridentGoalSeeker
    {
        public sealed class GoalSeeker
        {
            private readonly IGoalSeekAlgorithm algorithm;
            private decimal tineSpacing;
            private decimal onVariable;
            private bool lockTineExplore;
            private int iterations;
            public GoalSeeker(IGoalSeekAlgorithm algorithm)
            {
                this.algorithm = algorithm;
            }
            public SeekerResult DetermineInputVariable(decimal startVariable, decimal initialTineSpacing, decimal tineExplorePercentage, decimal acceptanceDistance, int maximumIterations, decimal goal)
            {
                var watch = new Stopwatch();
                watch.Start();
                if (initialTineSpacing == 0)
                    throw new Exception("Tine spacing cannot be zero.");
                iterations = 0;
                tineSpacing = initialTineSpacing;
                var tineOutFactor = tineExplorePercentage / 100;
                lockTineExplore = false;
                onVariable = startVariable;
                var breakOutDistance = acceptanceDistance / 100000000;
                while (true)
                {
                    iterations++;
                    var trident = StabTrident(onVariable);
                    var stabResult = GetStabResult(trident, acceptanceDistance, breakOutDistance, goal);
                    switch (stabResult.Result)
                    {
                        case StabResultEnum.Null:
                            watch.Stop();
                            return new SeekerResult(iterations, null, null, watch.ElapsedMilliseconds);
                        case StabResultEnum.NearLeft:
                            ApplyNearLeftFocus(stabResult, trident, tineOutFactor);
                            break;
                        case StabResultEnum.NearRight:
                            ApplyNearRightFocus(stabResult, trident, tineOutFactor);
                            break;
                        case StabResultEnum.NearMiddle:
                            lockTineExplore = true;
                            FocusTineSpacing(stabResult, trident);
                            break;
                        case StabResultEnum.Stab:
                            watch.Stop();
                            return new SeekerResult(iterations, trident.MiddleVariable, trident.MiddleValue, watch.ElapsedMilliseconds);
                        default:
                            throw new Exception($"Unable to determine the stab result of '{stabResult}'.");
                    }
                    if (iterations < maximumIterations)
                        continue;
                    watch.Stop();
                    return new SeekerResult(iterations, null, null, watch.ElapsedMilliseconds);
                }
            }
            private void ApplyNearLeftFocus(StabResult stabResult, Trident trident, decimal tineOutFactor)
            {
                onVariable = trident.LeftVariable;
                if (!lockTineExplore)
                    tineSpacing = tineSpacing + (tineSpacing * tineOutFactor);
                else
                    FocusTineSpacing(stabResult, trident);
            }
            private void ApplyNearRightFocus(StabResult stabResult, Trident trident, decimal tineOutFactor)
            {
                onVariable = trident.RightVariable;
                if (!lockTineExplore)
                    tineSpacing = tineSpacing + (tineSpacing * tineOutFactor);
                else
                    FocusTineSpacing(stabResult, trident);
            }
            private void FocusTineSpacing(StabResult stabResult, Trident trident)
            {
                if (stabResult.LeftDistance < stabResult.RightDistance)
                    tineSpacing = (trident.MiddleVariable - trident.LeftVariable) / 2;
                else
                    tineSpacing = (trident.RightVariable - trident.MiddleVariable) / 2;
            }
            private StabResult GetStabResult(Trident trident, decimal acceptDistance, decimal breakOutDistance, decimal goal)
            {
                var middleDistance = trident.MiddleValue.HasValue ? Math.Abs(goal - trident.MiddleValue.Value) : (decimal?)null;
                if (middleDistance <= acceptDistance)
                    return new StabResult(0, middleDistance, 0, StabResultEnum.Stab);
                if (Math.Abs(trident.RightVariable - trident.LeftVariable) <= breakOutDistance)
                    return new StabResult(0, middleDistance, 0, StabResultEnum.Stab);
                var leftDistance = trident.LeftValue.HasValue ? Math.Abs(goal - trident.LeftValue.Value) : (decimal?)null;
                var rightDistance = trident.RightValue.HasValue ? Math.Abs(goal - trident.RightValue.Value) : (decimal?)null;
                if (!leftDistance.HasValue && !rightDistance.HasValue && !middleDistance.HasValue)
                    return new StabResult(null, null, null, StabResultEnum.Null);
                if (middleDistance.HasValue)
                {
                    if (!leftDistance.HasValue && rightDistance.HasValue)
                        return middleDistance.Value < rightDistance.Value ? new StabResult(null, middleDistance, rightDistance, StabResultEnum.NearMiddle) : new StabResult(null, middleDistance, rightDistance, StabResultEnum.NearRight);
                    if (!rightDistance.HasValue && leftDistance.HasValue)
                        return middleDistance.Value < leftDistance.Value ? new StabResult(leftDistance, middleDistance, null, StabResultEnum.NearMiddle) : new StabResult(leftDistance, middleDistance, null, StabResultEnum.NearLeft);
                }
                else
                {
                    if (!leftDistance.HasValue)
                        return new StabResult(null, null, rightDistance, StabResultEnum.NearRight);
                    if (!rightDistance.HasValue)
                        return new StabResult(leftDistance, null, null, StabResultEnum.NearLeft);
                    return leftDistance.Value < rightDistance.Value ? new StabResult(leftDistance, null, rightDistance, StabResultEnum.NearLeft) :
                        new StabResult(leftDistance, null, rightDistance, StabResultEnum.NearRight);
                }
                if (middleDistance < leftDistance && middleDistance < rightDistance)
                    return new StabResult(leftDistance, middleDistance, rightDistance, StabResultEnum.NearMiddle);
                if (leftDistance < rightDistance)
                    return new StabResult(leftDistance, middleDistance, rightDistance, StabResultEnum.NearLeft);
                return new StabResult(leftDistance, middleDistance, rightDistance, StabResultEnum.NearRight);
            }
            private Trident StabTrident(decimal inputVariable)
            {
                var leftVariable = inputVariable - tineSpacing;
                var rightVariable = inputVariable + tineSpacing;
                var leftValue = SafeCalculate(leftVariable);
                var middleValue = SafeCalculate(inputVariable);
                var rightValue = SafeCalculate(rightVariable);
                return new Trident(leftVariable, leftValue, inputVariable, middleValue, rightVariable, rightValue);
            }
            private decimal? SafeCalculate(decimal value)
            {
                try
                {
                    return algorithm.Calculate(value);
                }
                catch
                {
                    return null;
                }
            }
        }
        public interface IGoalSeekAlgorithm
        {
            decimal Calculate(decimal inputVariable);
        }
        public class SeekerResult
        {
            private readonly int iterations;
            private readonly decimal? inputVariable;
            private readonly decimal? outputValue;
            private readonly long elapsedMilliseconds;
            public int Iterations
            {
                get
                {
                    return iterations;
                }
            }
            public decimal? InputVariable
            {
                get
                {
                    return inputVariable;
                }
            }
            public decimal? OutputValue
            {
                get
                {
                    return outputValue;
                }
            }
            public long ElapsedMilliseconds
            {
                get { return elapsedMilliseconds; }
            }
            public SeekerResult(int iterations, decimal? inputVariable, decimal? outputValue, long elapsedMilliseconds)
            {
                this.iterations = iterations;
                this.inputVariable = inputVariable;
                this.outputValue = outputValue;
                this.elapsedMilliseconds = elapsedMilliseconds;
            }
        }
        internal enum StabResultEnum
        {
            Null,
            NearLeft,
            NearMiddle,
            NearRight,
            Stab
        }
        internal class StabResult
        {
            private readonly decimal? leftDistance;
            private readonly decimal? middleDistance;
            private readonly decimal? rightDistance;
            private readonly StabResultEnum result;
            public override string ToString()
            {
                return string.Format("Near: {0}. L:{1}, M:{2}, R:{3}", result, leftDistance, middleDistance, rightDistance);
            }
            public decimal? LeftDistance
            {
                get
                {
                    return leftDistance;
                }
            }
            public decimal? MiddleDistance
            {
                get
                {
                    return middleDistance;
                }
            }
            public decimal? RightDistance
            {
                get
                {
                    return rightDistance;
                }
            }
            internal StabResultEnum Result
            {
                get
                {
                    return result;
                }
            }
            public StabResult(decimal? leftDistance, decimal? middleDistance, decimal? rightDistance, StabResultEnum result)
            {
                this.leftDistance = leftDistance;
                this.middleDistance = middleDistance;
                this.rightDistance = rightDistance;
                this.result = result;
            }
        }
        internal class Trident
        {
            private readonly decimal leftVariable;
            private readonly decimal? leftValue;
            private readonly decimal middleVariable;
            private readonly decimal? middleValue;
            private readonly decimal rightVariable;
            private readonly decimal? rightValue;
            public Trident(decimal leftVariable, decimal? leftValue, decimal middleVariable, decimal? middleValue, decimal rightVariable, decimal? rightValue)
            {
                this.leftVariable = leftVariable;
                this.leftValue = leftValue;
                this.middleVariable = middleVariable;
                this.middleValue = middleValue;
                this.rightVariable = rightVariable;
                this.rightValue = rightValue;
            }
            public decimal LeftVariable
            {
                get
                {
                    return leftVariable;
                }
            }
            public decimal? LeftValue
            {
                get
                {
                    return leftValue;
                }
            }
            public decimal MiddleVariable
            {
                get
                {
                    return middleVariable;
                }
            }
            public decimal? MiddleValue
            {
                get
                {
                    return middleValue;
                }
            }
            public decimal RightVariable
            {
                get
                {
                    return rightVariable;
                }
            }
            public decimal? RightValue
            {
                get
                {
                    return rightValue;
                }
            }
        }
    }
