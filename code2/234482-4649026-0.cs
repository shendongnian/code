    result = MatchingRefinement.VoteForSizeAndOrientation(result, 1.5, 20);
            homography = MatchingRefinement.GetHomographyMatrixFromMatchedFeatures(result, HomographyDirection.DIRECT, HOMOGRAPHY_METHOD.LMEDS);
            inverseHomography = MatchingRefinement.GetHomographyMatrixFromMatchedFeatures(result, HomographyDirection.INVERSE, HOMOGRAPHY_METHOD.LMEDS);
            PointF[] pts1 = new PointF[result.Length];
            PointF[] pts1_t = new PointF[result.Length];
            PointF[] pts2 = new PointF[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                pts1[i] = result[i].ObservedFeature.KeyPoint.Point;
                pts1_t[i] = result[i].ObservedFeature.KeyPoint.Point;
                pts2[i] = result[i].SimilarFeatures[0].Feature.KeyPoint.Point;
            }
            // Project model features according to homography
            homography.ProjectPoints(pts1_t);
            Image<Bgr, Byte> finalCorrespondance = inputImage.Copy();
            matchedInliersFeatures = new List<MatchedImageFeature>();
            for (int i1 = 0; i1 < pts1_t.Length; i1++)
            {
                
                if (Math.Sqrt(Math.Pow(pts2[i1].X - pts1_t[i1].X, 2d) + Math.Pow(pts2[i1].Y - pts1_t[i1].Y, 2d)) <4d) // Inlier
                {
                    PointF p_t = pts1_t[i1];
                    PointF p = pts1[i1];
                    finalCorrespondance.Draw(new CircleF(p, 2f), new Bgr(Color.Yellow), 2);
                    finalCorrespondance.Draw(new CircleF(p_t, 2f), new Bgr(Color.Black), 2);
                    finalCorrespondance.Draw(new LineSegment2DF(p, p_t), new Bgr(Color.Blue), 1);
                    MatchedImageFeature feature = new MatchedImageFeature();
                    feature.SimilarFeatures = new SimilarFeature[] { result[i1].SimilarFeatures[0] };
                    feature.ObservedFeature = result[i1].ObservedFeature;
                    matchedInliersFeatures.Add(feature);
                }
            }
            List<ImageFeature> inliers = new List<ImageFeature>();
            foreach (MatchedImageFeature match in matchedInliersFeatures)
            {
                inliers.Add(match.ObservedFeature);
                inliers.Add(match.SimilarFeatures[0].Feature);
            }
